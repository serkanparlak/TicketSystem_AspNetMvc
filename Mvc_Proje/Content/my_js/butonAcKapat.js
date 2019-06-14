function butonAcKapat(a) {
    $.ajax({
        url: '/User/TicketDurumu?id=' + a,
        method: 'POST',
        success: function (sonuc) {
            if (sonuc) {
                $("#btnDurum-" + a).removeClass("btn-success")
                $("#btnDurum-" + a).addClass("btn-primary")
                $("#btnDurum-" + a).text("Açık")
            }
            else {
                $("#btnDurum-" + a).removeClass("btn-primary")
                $("#btnDurum-" + a).addClass("btn-success")
                $("#btnDurum-" + a).text("Kapalı")
            }

        },
        error: function () {
            alert("hata")
        }
    });
}