// ===== Sticky Navbar Shadow =====
window.addEventListener("scroll", function () {
    const navbar = document.querySelector(".navbar");
    if (window.scrollY > 50) {
        navbar.classList.add("scrolled");
    } else {
        navbar.classList.remove("scrolled");
    }
});

// ===== Button Ripple Effect =====
document.querySelectorAll("button").forEach(btn => {
    btn.addEventListener("click", function (e) {
        const ripple = document.createElement("span");
        ripple.className = "ripple";
        ripple.style.left = e.offsetX + "px";
        ripple.style.top = e.offsetY + "px";
        this.appendChild(ripple);

        setTimeout(() => ripple.remove(), 600);
    });
});

// ===== Smooth Page Transition =====
document.addEventListener("DOMContentLoaded", () => {
    document.body.style.opacity = 0;
    document.body.style.transition = "opacity 0.5s ease-in-out";
    setTimeout(() => {
        document.body.style.opacity = 1;
    }, 50);
});
