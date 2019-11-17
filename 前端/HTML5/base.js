export function modal() {
    initModal();
}
function initModal(){
    let windowHeight = window.innerHeight;
    let windowWidth = window.innerWidth;
    let $modals = $(".modal");
    for (let i = 0; i < $modals.length; i++) {
        let modalHeight = $modals.eq(i).height();
        let modalWidth = $modals.eq(i).width();
        $modals.eq(i).css("top", ((windowHeight - modalHeight) / 2) + "px");
        $modals.eq(i).css("left", ((windowWidth - modalWidth) / 2) + "px");
    }
}
$(window).resize(function () {
    initModal();
});
