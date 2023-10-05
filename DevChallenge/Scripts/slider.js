const corousel = document.querySelector(".image-cards");
const arrowBtn = document.querySelectorAll(".wrapper i");
const firstCardWidth = corousel.querySelector(".img-card").offsetWidth;
const carouselChildren = [...corousel.children];


let isDragging = false, startX, startScrollLeft;
let cardPerView = Math.round(corousel.offsetWidth / firstCardWidth);

carouselChildren.slice(-cardPerView).reverse().forEach(card => {
    corousel.insertAdjacentHTML("afterbegin", card.outerHTML);
});

carouselChildren.slice(0, cardPerView).forEach(card => {
    corousel.insertAdjacentHTML("beforeend", card.outerHTML);
});

arrowBtn.forEach(btn => {
    btn.addEventListener("click", () => {
        //console.log(btn.id);
        corousel.scrollLeft += btn.id === "left" ? -firstCardWidth : firstCardWidth;
    })
})

const dragStart = (e) => {
    isDragging = true;
    corousel.classList.add("dragging");
    startX = e.pageX;
    startScrollLeft = corousel.scrollLeft;
}


const dragging = (e) => {
    if (!isDragging) return;
    corousel.scrollLeft = startScrollLeft - (e.pageX - startX);
    //console.log(e.pageX);
}

const dragStop = () => {
    isDragging = false;
    corousel.classList.remove("dragging");
}

const infiniteScroll = () => {
    if (corousel.scrollLeft === 0) {
        corousel.classList.add("no-transition");
        corousel.scrollLeft = corousel.scrollWidth - (2 * corousel.offsetWidth);
        corousel.classList.remove("no-transition");

    } else if (Math.ceil(corousel.scrollLeft) === corousel.scrollWidth - corousel.offsetWidth) {
        corousel.classList.add("no-transition");
        corousel.scrollLeft = corousel.offsetWidth;
        corousel.classList.remove("no-transition");
    }
}

corousel.addEventListener("mousedown", dragStart);
corousel.addEventListener("mousemove", dragging);
document.addEventListener("mouseup", dragStop);
corousel.addEventListener("scroll", infiniteScroll);