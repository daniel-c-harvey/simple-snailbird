// Reconnect mode: 0 = Silent (don't show), 1 = Visible (show)
// This is a global variable that can be set by C# interop
window.reconnectMode = 0;

/**
 * Set the reconnect mode from C# interop
 * @param {number} mode - 0 for Silent, 1 for Visible
 */
window.setReconnectMode = function(mode) {
    window.reconnectMode = mode;
    console.log(`Reconnect mode set to: ${mode === 0 ? 'Silent' : 'Visible'}`);
};

// Initialize reconnect modal when DOM is ready
document.addEventListener('DOMContentLoaded', function() {
    const reconnectModal = document.getElementById("components-reconnect-modal");
    if (!reconnectModal) {
        console.warn("Reconnect modal element not found");
        return;
    }

    // Set up event handlers
    reconnectModal.addEventListener("components-reconnect-state-changed", handleReconnectStateChanged);

    const retryButton = document.getElementById("components-reconnect-button");
    if (retryButton) {
        retryButton.addEventListener("click", retry);
    }

    const resumeButton = document.getElementById("components-resume-button");
    if (resumeButton) {
        resumeButton.addEventListener("click", resume);
    }

    function handleReconnectStateChanged(event) {
        if (event.detail.state === "show") {
            // Only show modal if reconnect mode is Visible (1)
            if (window.reconnectMode === 1) {
                reconnectModal.showModal();
            }
            else {
                console.log("Reconnect modal suppressed due to Silent mode.");
                // Immediately attempt to retry reconnecting
                retry();
            }
        } else if (event.detail.state === "hide") {
            reconnectModal.close();
        } else if (event.detail.state === "failed") {
            document.addEventListener("visibilitychange", retryWhenDocumentBecomesVisible);
        } else if (event.detail.state === "rejected") {
            location.reload();
        }
    }

    async function retry() {
        document.removeEventListener("visibilitychange", retryWhenDocumentBecomesVisible);

        try {
            // Reconnect will asynchronously return:
            // - true to mean success
            // - false to mean we reached the server, but it rejected the connection (e.g., unknown circuit ID)
            // - exception to mean we didn't reach the server (this can be sync or async)
            const successful = await Blazor.reconnect();
            if (!successful) {
                // We have been able to reach the server, but the circuit is no longer available.
                // We'll reload the page so the user can continue using the app as quickly as possible.
                const resumeSuccessful = await Blazor.resumeCircuit();
                if (!resumeSuccessful) {
                    location.reload();
                } else {
                    reconnectModal.close();
                }
            }
        } catch (err) {
            // We got an exception, server is currently unavailable
            document.addEventListener("visibilitychange", retryWhenDocumentBecomesVisible);
        }
    }

    async function resume() {
        try {
            const successful = await Blazor.resumeCircuit();
            if (!successful) {
                location.reload();
            }
        } catch {
            location.reload();
        }
    }

    async function retryWhenDocumentBecomesVisible() {
        if (document.visibilityState === "visible") {
            await retry();
        }
    }
});
