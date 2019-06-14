$(document).ready(function () {
    $.ajax({
        url: '/User/ticketKontrol',
        type: 'POST',
        success: function (sonuc) {
            if (sonuc != "Bos") {
                if (sonuc) {
                    $("#mesaj_div").fadeIn("slow");
                    setTimeout(function () {
                        $("#mesaj_div").slideUp("slow", "swing")
                    }, 4000)
                }
                else {
                    $("#clasDanger").toggleClass("alert-danger")
                    $("#mesaj").html("Bir hata oluştu")
                    $("#mesaj_div").fadeIn("slow");
                    setTimeout(function () {
                        $("#mesaj_div").slideUp("slow", "swing")
                    }, 4000)
                }
            }
        }
    });

    // Bu kısımı bulmak çok zor oldu
    var unloadEvent = function (e) {
        $.ajax({
            type: 'POST',
            url: '/User/viewTemizle'
        });
    };
    window.addEventListener("beforeunload", unloadEvent);
})