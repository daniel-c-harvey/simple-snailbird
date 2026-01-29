/**
 * ParallaxView - Pure JavaScript scroll handler for smooth parallax effects
 *
 * Design principles:
 * - All visual updates in JS for 60fps performance
 * - WeakMap for multi-instance support (no global state pollution)
 * - Transforms applied to container, not children (generic content support)
 * - requestAnimationFrame for smooth updates
 * - Passive scroll listeners for scroll performance
 */

// Store instance data keyed by container element (auto garbage-collected)
const instances = new WeakMap();

/**
 * Initialize parallax effect on a container
 * @param {HTMLElement} container - The .parallax-container element
 * @param {Object} options - Configuration options
 */
export function init(container, options) {
    if (!container || instances.has(container)) return;

    const wrapper = container.querySelector('.parallax-background-wrapper');
    const background = container.querySelector('.parallax-background');
    if (!wrapper || !background) return;

    const { parallaxSpeed = 0.5, enableFade = true, fadeIntensity = 1.0 } = options;

    // Cache dimensions (recalculated on resize)
    let wrapperHeight = wrapper.offsetHeight;
    let wrapperTop = wrapper.getBoundingClientRect().top + window.scrollY;

    // Track animation frame to prevent duplicate calls
    let rafId = null;

    /**
     * Core update function - called on scroll via requestAnimationFrame
     */
    function update() {
        rafId = null;

        const scrollY = window.scrollY;

        // Calculate scroll relative to wrapper position
        const relativeScroll = Math.max(0, scrollY - wrapperTop);

        // Don't process if scrolled way past the background
        if (relativeScroll > wrapperHeight * 2) return;

        // === PARALLAX EFFECT ===
        // Background is absolutely positioned (scrolls with page normally).
        // Translate it DOWN (positive Y) to counteract some of the scroll,
        // making it appear to scroll slower than the foreground.
        const counteractAmount = 1 - parallaxSpeed;
        const parallaxOffset = relativeScroll * counteractAmount;
        background.style.transform = `translateY(${parallaxOffset}px)`;

        // === FADE EFFECT ===
        if (enableFade) {
            // Calculate how much the foreground has covered the background
            const scrollProgress = Math.min(relativeScroll / wrapperHeight, 1);
            const fadeProgress = Math.min(scrollProgress * fadeIntensity, 1);

            // Opacity: 1 (fully visible) -> 0 (fully transparent)
            const opacity = 1 - fadeProgress;
            background.style.opacity = opacity;
        }
    }

    /**
     * Scroll handler - requests animation frame for smooth updates
     */
    function onScroll() {
        if (rafId === null) {
            rafId = requestAnimationFrame(update);
        }
    }

    /**
     * Resize handler - recalculate dimensions
     */
    function onResize() {
        wrapperHeight = wrapper.offsetHeight;
        wrapperTop = wrapper.getBoundingClientRect().top + window.scrollY;
        update();
    }

    // Attach event listeners
    window.addEventListener('scroll', onScroll, { passive: true });
    window.addEventListener('resize', onResize, { passive: true });

    // Initial update
    update();

    // Store instance data for cleanup
    instances.set(container, {
        onScroll,
        onResize,
        getRafId: () => rafId
    });
}

/**
 * Clean up event listeners and state for a container
 * @param {HTMLElement} container - The container to clean up
 */
export function destroy(container) {
    const instance = instances.get(container);
    if (!instance) return;

    window.removeEventListener('scroll', instance.onScroll);
    window.removeEventListener('resize', instance.onResize);

    // Cancel any pending animation frame
    const rafId = instance.getRafId();
    if (rafId !== null) {
        cancelAnimationFrame(rafId);
    }

    // Reset styles
    const background = container.querySelector('.parallax-background');
    if (background) {
        background.style.transform = '';
        background.style.opacity = '';
    }

    instances.delete(container);
}
