const listings = [
    /* ---------- Education ---------- */
    {
        id: 1, type: "tutor", category: "Education", title: "Mathematics Tutor", name: "Angelica Reyes", initials: "AR", color: "#dbeafe",
        description: "I can help with algebra, geometry, and basic calculus.", rating: 4.8, price: 300, reviews: 42
    },
    {
        id: 2, type: "tutor", category: "Education", title: "English Language Tutor", name: "Kristine Bautista", initials: "KB", color: "#fef3c7",
        description: "Friendly English lessons for speaking, writing, and grammar.", rating: 4.7, price: 250, reviews: 35
    },
    {
        id: 3, type: "tutor", category: "Education", title: "Science Tutor", name: "Paolo Villanueva", initials: "PV", color: "#d1fae5",
        description: "Physics, chemistry, and biology explained in a simple way.", rating: 4.8, price: 350, reviews: 33
    },

    /* ---------- Technology ---------- */
    {
        id: 4, type: "tutor", category: "Technology", title: "Computer Programming Tutor", name: "Mark Dela Cruz", initials: "MD", color: "#dcfce7",
        description: "Learn the basics of C#, HTML, CSS, and web development.", rating: 4.9, price: 400, reviews: 67
    },
    {
        id: 5, type: "service", category: "Technology", title: "Computer Repair", name: "Jericho Ramos", initials: "JR", color: "#ede9fe",
        description: "I fix common laptop and desktop computer problems.", rating: 4.6, price: 500, reviews: 28
    },
    {
        id: 6, type: "service", category: "Technology", title: "Website Development", name: "Carlo Mendoza", initials: "CM", color: "#e0f2fe",
        description: "Simple business websites and landing pages built for you.", rating: 4.9, price: 700, reviews: 54
    },
    {
        id: 7, type: "service", category: "Technology", title: "Phone & Gadget Repair", name: "Renz Aquino", initials: "RA", color: "#fae8ff",
        description: "Cracked screens, battery replacement, and other phone fixes.", rating: 4.5, price: 400, reviews: 41
    },

    /* ---------- Design ---------- */
    {
        id: 8, type: "service", category: "Design", title: "Graphic Design", name: "Bea Fernandez", initials: "BF", color: "#fce7f3",
        description: "Simple logos, posters, social media posts, and invitations.", rating: 4.8, price: 600, reviews: 51
    },
    {
        id: 9, type: "service", category: "Design", title: "Video Editing", name: "Camille Torres", initials: "CT", color: "#ffe4e6",
        description: "Edit videos for YouTube, TikTok, events, and presentations.", rating: 4.7, price: 550, reviews: 37
    },
    {
        id: 10, type: "service", category: "Design", title: "Photography", name: "Miguel Castillo", initials: "MC", color: "#fef9c3",
        description: "Portraits, product photos, and small event photography.", rating: 4.9, price: 800, reviews: 62
    },
    {
        id: 11, type: "tutor", category: "Design", title: "UI/UX Design Tutor", name: "Janine Navarro", initials: "JN", color: "#ede9fe",
        description: "Learn wireframing, color, and how to design clean app screens.", rating: 4.8, price: 450, reviews: 29
    },

    /* ---------- Home ---------- */
    {
        id: 12, type: "service", category: "Home", title: "Home Repair Help", name: "Joshua Pascual", initials: "JP", color: "#ffedd5",
        description: "Help with furniture assembly and small household repairs.", rating: 4.7, price: 450, reviews: 39
    },
    {
        id: 13, type: "service", category: "Home", title: "House Cleaning", name: "Grace Domingo", initials: "GD", color: "#ccfbf1",
        description: "Thorough cleaning for apartments, houses, and small offices.", rating: 4.8, price: 350, reviews: 76
    },
    {
        id: 14, type: "service", category: "Home", title: "Plumbing & Electrical", name: "Rafael Gonzales", initials: "RG", color: "#e2e8f0",
        description: "Fix leaks, install lights, and repair outlets safely.", rating: 4.6, price: 550, reviews: 48
    },
    {
        id: 15, type: "service", category: "Home", title: "Gardening & Landscaping", name: "Nicole Salazar", initials: "NS", color: "#dcfce7",
        description: "Lawn care, planting, and garden cleanup for your home.", rating: 4.7, price: 400, reviews: 31
    },

    /* ---------- Music ---------- */
    {
        id: 16, type: "tutor", category: "Music", title: "Guitar Lessons", name: "Angelo Garcia", initials: "AG", color: "#ffedd5",
        description: "Acoustic and electric guitar for beginners and improvers.", rating: 4.8, price: 350, reviews: 44
    },
    {
        id: 17, type: "tutor", category: "Music", title: "Piano Tutor", name: "Andrea Ocampo", initials: "AO", color: "#fce7f3",
        description: "Learn to read music and play your favorite songs.", rating: 4.9, price: 400, reviews: 58
    },
    {
        id: 18, type: "tutor", category: "Music", title: "Vocal Coach", name: "Jhoanna Lim", initials: "JL", color: "#fae8ff",
        description: "Improve your singing, breathing, and stage confidence.", rating: 4.7, price: 450, reviews: 26
    },

    /* ---------- Fitness ---------- */
    {
        id: 19, type: "service", category: "Fitness", title: "Personal Trainer", name: "Christian Santos", initials: "CS", color: "#fee2e2",
        description: "Custom workout plans and one-on-one training sessions.", rating: 4.8, price: 600, reviews: 69
    },
    {
        id: 20, type: "tutor", category: "Fitness", title: "Yoga Instructor", name: "Patricia Cruz", initials: "PC", color: "#d1fae5",
        description: "Relaxing yoga classes for flexibility, balance, and calm.", rating: 4.9, price: 350, reviews: 52
    },
    {
        id: 21, type: "tutor", category: "Fitness", title: "Swimming Coach", name: "John Paul Tan", initials: "JT", color: "#cffafe",
        description: "Learn to swim or improve your technique, kids and adults.", rating: 4.7, price: 500, reviews: 34
    },

    /* ---------- Business ---------- */
    {
        id: 22, type: "service", category: "Business", title: "Accounting & Bookkeeping", name: "Maricel Soriano", initials: "MS", color: "#e0e7ff",
        description: "Organize your records, receipts, and monthly reports.", rating: 4.8, price: 550, reviews: 36
    },
    {
        id: 23, type: "service", category: "Business", title: "Resume & Cover Letter Help", name: "Ramon Aguilar", initials: "RA", color: "#fef3c7",
        description: "Professional resumes and cover letters that get noticed.", rating: 4.7, price: 400, reviews: 47
    },
    {
        id: 24, type: "service", category: "Business", title: "Social Media Marketing", name: "Louise Mercado", initials: "LM", color: "#fce7f3",
        description: "Grow your small business with posts, ads, and page setup.", rating: 4.6, price: 500, reviews: 30
    },

    /* ---------- Beauty & Care ---------- */
    {
        id: 25, type: "service", category: "Beauty & Care", title: "Haircut & Styling", name: "Rhea Manalo", initials: "RM", color: "#ffe4e6",
        description: "Haircuts, coloring, and styling at your home or my studio.", rating: 4.8, price: 300, reviews: 83
    },
    {
        id: 26, type: "service", category: "Beauty & Care", title: "Makeup Artist", name: "Trisha Valdez", initials: "TV", color: "#fae8ff",
        description: "Makeup for weddings, parties, graduations, and photoshoots.", rating: 4.9, price: 700, reviews: 57
    },
    {
        id: 27, type: "service", category: "Beauty & Care", title: "Massage Therapy", name: "Dennis Padilla", initials: "DP", color: "#ccfbf1",
        description: "Relaxing full-body and back massage to relieve stress.", rating: 4.7, price: 600, reviews: 45
    }
];

const serviceImages = {
    1: "/images/services/math.jpg",
    2: "/images/services/english.jpg",
    3: "/images/services/science.jpg",
    4: "/images/services/programming.jpg",
    5: "/images/services/computer-repair.jpg",
    6: "/images/services/website.jpg",
    7: "/images/services/phone-repair.jpg",
    8: "/images/services/graphic-design.jpg",
    9: "/images/services/video-editing.jpg",
    10: "/images/services/photography.jpg",
    11: "/images/services/uiux.jpg",
    12: "/images/services/home-repair.jpg",
    13: "/images/services/cleaning.jpg",
    14: "/images/services/plumbing.jpg",
    15: "/images/services/gardening.jpg",
    16: "/images/services/guitar.jpg",
    17: "/images/services/piano.jpg",
    18: "/images/services/vocal.jpg",
    19: "/images/services/trainer.jpg",
    20: "/images/services/yoga.jpg",
    21: "/images/services/swimming.jpg",
    22: "/images/services/accounting.jpg",
    23: "/images/services/resume.jpg",
    24: "/images/services/social-media.jpg",
    25: "/images/services/haircut.jpg",
    26: "/images/services/makeup.jpg",
    27: "/images/services/massage.jpg"
};

/* Backup pictures by category (only used if a service has no picture listed above) */
const categoryImages = {
    "Education": "/images/categories/education.jpg",
    "Technology": "/images/categories/technology.jpg",
    "Design": "/images/categories/design.jpg",
    "Home": "/images/categories/home.jpg",
    "Music": "/images/categories/music.jpg",
    "Fitness": "/images/categories/fitness.jpg",
    "Business": "/images/categories/business.jpg",
    "Beauty & Care": "/images/categories/beauty.jpg"
};

const getImage = (item) => serviceImages[item.id] || item.image || categoryImages[item.category] || "";

/* ---------- State ---------- */
const state = { category: "All", type: "all", query: "" };

/* ---------- Elements ---------- */
const $ = (sel, root = document) => root.querySelector(sel);
const $$ = (sel, root = document) => [...root.querySelectorAll(sel)];

const grid = $("#listingGrid");
const emptyState = $("#emptyState");
const resultCount = $("#resultCount");
const searchInput = $("#searchInput");

/* ---------- Helpers ---------- */
const escapeHTML = (str) =>
    String(str).replace(/[&<>"']/g, (c) => ({ "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': "&quot;", "'": "&#39;" }[c]));

const starSVG = `<svg class="icon star" viewBox="0 0 24 24"><polygon points="12 2 15.09 8.26 22 9.27 17 14.14 18.18 21.02 12 17.77 5.82 21.02 7 14.14 2 9.27 8.91 8.26 12 2"/></svg>`;

let toastTimer;
function showToast(message) {
    const toast = $("#toast");
    toast.textContent = message;
    toast.classList.add("show");
    clearTimeout(toastTimer);
    toastTimer = setTimeout(() => toast.classList.remove("show"), 2800);
}

/* ---------- Build category buttons from the data ---------- */
function buildFilters() {
    const categories = ["All", ...new Set(listings.map((l) => l.category))];
    $("#filters").innerHTML = categories
        .map(
            (c, i) =>
                `<button class="filter-btn${i === 0 ? " active" : ""}" data-category="${escapeHTML(c)}">${escapeHTML(c)}</button>`
        )
        .join("");
}

/* ---------- Render listings ---------- */
function getFiltered() {
    const words = state.query.trim().toLowerCase().split(/\s+/).filter(Boolean);

    // Searching: use ONLY the words, ignore all filters
    if (words.length > 0) {
        return listings.filter((item) => {
            const haystack = [item.title, item.name, item.description, item.category, item.type]
                .join(" ")
                .toLowerCase();

            return words.every((w) => {
                const root = w.length > 3 && w.endsWith("s") ? w.slice(0, -1) : w;
                return haystack.includes(root);
            });
        });
    }

    // Not searching: use the category buttons and the big cards
    return listings.filter((item) => {
        const matchCategory = state.category === "All" || item.category === state.category;
        const matchType = state.type === "all" || item.type === state.type;
        return matchCategory && matchType;
    });
}

function render() {
    const items = getFiltered();

    grid.innerHTML = items
        .map((item, i) => {
            const img = getImage(item);
            const bg = img ? `--bg-img:url('${escapeHTML(img)}');` : "";
            return `
      <article class="card" style="--bg-color:${item.color};${bg}animation-delay:${Math.min(i, 8) * 60}ms">
        <div class="card-top">
          <div class="avatar" style="background:${item.color}">${escapeHTML(item.initials)}</div>
          <span class="badge ${item.type}">${item.type === "tutor" ? "Tutor" : "Service"}</span>
        </div>
        <h3>${escapeHTML(item.title)}</h3>
        <p class="by">${escapeHTML(item.name)}</p>
        <p class="desc">${escapeHTML(item.description)}</p>
        <div class="card-foot">
          <div>
            <div class="rating">${starSVG}<span>${item.rating.toFixed(1)}</span></div>
            <div class="price"><strong>₱${item.price}</strong> / hour</div>
          </div>
          <button class="btn btn-primary" data-details="${item.id}">View Details</button>
        </div>
      </article>`;
        })
        .join("");

    const hasResults = items.length > 0;
    emptyState.hidden = hasResults;
    grid.hidden = !hasResults;
    resultCount.textContent = `${items.length} ${items.length === 1 ? "result" : "results"}`;
}

/* ---------- Helpers to reset things ---------- */
/* Puts the category buttons and big cards back to "All" */
function resetFilterButtons() {
    state.category = "All";
    state.type = "all";
    $$(".filter-btn").forEach((b) => b.classList.toggle("active", b.dataset.category === "All"));
    $$(".quick-card").forEach((c) => c.classList.toggle("active", c.dataset.type === "all"));
}

/* Clears the search text */
function clearSearchText() {
    state.query = "";
    searchInput.value = "";
}

/* ---------- Filters (categories) ---------- */
$("#filters").addEventListener("click", (e) => {
    const btn = e.target.closest(".filter-btn");
    if (!btn) return;
    clearSearchText();
    state.category = btn.dataset.category;
    $$(".filter-btn").forEach((b) => b.classList.toggle("active", b === btn));
    render();
});

/* ---------- Quick cards (type filter) ---------- */
$$(".quick-card").forEach((card) => {
    card.addEventListener("click", () => {
        clearSearchText();
        state.type = card.dataset.type;
        $$(".quick-card").forEach((c) => c.classList.toggle("active", c === card));
        render();
        $("#browse").scrollIntoView({ behavior: "smooth" });
    });
});

/* ---------- Search ---------- */
function runSearch(value) {
    state.query = value;
    resetFilterButtons();
    render();
    $("#browse").scrollIntoView({ behavior: "smooth" });
}

$("#searchForm").addEventListener("submit", (e) => {
    e.preventDefault();
    runSearch(searchInput.value);
});

$$(".chip").forEach((chip) =>
    chip.addEventListener("click", () => {
        searchInput.value = chip.dataset.search;
        runSearch(chip.dataset.search);
    })
);

/* Live search while typing (without scrolling) */
searchInput.addEventListener("input", () => {
    state.query = searchInput.value;
    resetFilterButtons();
    render();
});

/* ---------- Reset ---------- */
$("#resetBtn").addEventListener("click", () => {
    clearSearchText();
    resetFilterButtons();
    render();
});

/* ---------- Modals ---------- */
function openModal(modal) {
    modal.classList.add("open");
    modal.setAttribute("aria-hidden", "false");
    document.body.style.overflow = "hidden";
}
function closeModal(modal) {
    modal.classList.remove("open");
    modal.setAttribute("aria-hidden", "true");
    document.body.style.overflow = "";
}

$$(".modal").forEach((modal) => {
    modal.addEventListener("click", (e) => {
        if (e.target.hasAttribute("data-close")) closeModal(modal);
    });
});
document.addEventListener("keydown", (e) => {
    if (e.key === "Escape") $$(".modal.open").forEach(closeModal);
});

/* Details modal */
const detailModal = $("#detailModal");

grid.addEventListener("click", (e) => {
    const btn = e.target.closest("[data-details]");
    if (!btn) return;
    const item = listings.find((l) => l.id === Number(btn.dataset.details));
    if (!item) return;

    $("#modalBody").innerHTML = `
    <div class="detail-head">
      <div class="avatar" style="background:${item.color}">${escapeHTML(item.initials)}</div>
      <div>
        <h2 id="modalTitle">${escapeHTML(item.title)}</h2>
        <p>${escapeHTML(item.name)} · <span class="badge ${item.type}">${item.type === "tutor" ? "Tutor" : "Service"}</span></p>
      </div>
    </div>
    <p class="detail-desc">${escapeHTML(item.description)}</p>
    <div class="detail-meta">
      <div class="meta-box"><strong>★ ${item.rating.toFixed(1)}</strong><span>${item.reviews} reviews</span></div>
      <div class="meta-box"><strong>₱${item.price}</strong><span>per hour</span></div>
      <div class="meta-box"><strong>${escapeHTML(item.category)}</strong><span>category</span></div>
    </div>
    <form class="form" id="requestForm">
      <label>Your name
        <input type="text" placeholder="Enter your name" required />
      </label>
      <label>Message
        <textarea rows="3" placeholder="Tell ${escapeHTML(item.name.split(" ")[0])} what you need..." required></textarea>
      </label>
      <button type="submit" class="btn btn-primary block">Send Request</button>
    </form>`;

    $("#requestForm").addEventListener("submit", (ev) => {
        ev.preventDefault();
        closeModal(detailModal);
        showToast(`Request sent to ${item.name}!`);
    });

    openModal(detailModal);
});

/* Login modal */
const loginModal = $("#loginModal");
$("#loginBtn").addEventListener("click", () => {
    closeMenu();
    openModal(loginModal);
});
$("#loginForm").addEventListener("submit", (e) => {
    e.preventDefault();
    closeModal(loginModal);
    e.target.reset();
    showToast("Login form submitted (connect to your ASP.NET backend).");
});

/* ---------- Navbar: mobile menu, scroll shadow, active link ---------- */
const menuToggle = $("#menuToggle");
const navLinks = $("#navLinks");

function closeMenu() {
    menuToggle.classList.remove("open");
    navLinks.classList.remove("open");
    menuToggle.setAttribute("aria-expanded", "false");
}
menuToggle.addEventListener("click", () => {
    const open = menuToggle.classList.toggle("open");
    navLinks.classList.toggle("open", open);
    menuToggle.setAttribute("aria-expanded", String(open));
});
$$(".nav-link").forEach((l) => l.addEventListener("click", closeMenu));

window.addEventListener("scroll", () => {
    $("#navbar").classList.toggle("scrolled", window.scrollY > 10);
});

const sections = ["home", "browse", "about"].map((id) => document.getElementById(id));
const observer = new IntersectionObserver(
    (entries) => {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                $$(".nav-link").forEach((a) =>
                    a.classList.toggle("active", a.getAttribute("href") === `#${entry.target.id}`)
                );
            }
        });
    },
    { rootMargin: "-45% 0px -50% 0px" }
);
sections.forEach((s) => s && observer.observe(s));

/* ---------- Init ---------- */
$("#year").textContent = new Date().getFullYear();
buildFilters();
render();