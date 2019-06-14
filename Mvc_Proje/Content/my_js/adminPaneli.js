function adminSil(id) {
    if (id != null & confirm("Yetkiyi kaldırmak istediğinize eminmisiniz")) {
        $.ajax({
            method: 'POST',
            url: '/Admin/adminSil?id=' + id,
            success: function (sonuc) {
                if (sonuc.IsSuccess) {
                    var kAdi = $("#kulAdi-" + id).text();
                    $("#tr-" + id).fadeOut();
                    $("#kul").append(
                        "<option id='op-" + id + "' value='" + id + "'>" + kAdi + "</option>"
                        )
                }
                else {
                    $("#mesaj").html(sonuc.Mesaj)
                    $("#mesaj").fadeIn("fast")
                    setTimeout(function () {
                        $("#mesaj").slideUp("slow")
                    }, 3000)
                }
            },
            error: function () {
                $("#mesaj").html("Bilinmeyen bir hata oluştu")
                $("#mesaj").fadeIn("fast")
                setTimeout(function () {
                    $("#mesaj").slideUp("slow")
                }, 3000)
            }
        })
    }
}
function yetkiVer() {
    var id = $("#kul").val();
    if (id == "") {
        $("#duyuru").fadeIn("fast").html("Kullanıcı seçmediniz")
        setTimeout(function () {
            $("#duyuru").slideUp("fast")
        }, 2000)
    }
    else if (confirm("Bu kullanıcının tüm ticketları ve yorumları silinecek - Onaylıyormusunuz?")) {
        $.ajax({
            method: 'POST',
            url: '/Admin/yetkiVer?id=' + id,
            success: function (result) {
                if (result.IsSuccess) {
                    var kulAdi = $("#op-" + id).text();
                    $("tbody").append(
                        "<tr id='tr-" + id + "' hidden>" +
                                        "<td>" + id + "</td>" +
                                        "<td id='kulAdi-" + id + "' style='width:300px'>" + kulAdi + "</td>" +
                                        "<td>" +
    "<input type='button' id='btn-" + id + "' class='btn btn-danger btn-xs' onclick='adminSil(" + id + ")' value='Kaldır'>" +
                                        "</td>" +
                        "</tr>"
                    )
                    $("#tr-" + id).fadeIn();
                    $("#op-" + id).remove();
                }
                else {
                    $("#duyuru").fadeIn("fast").html(result.Mesaj)
                    setTimeout(function () {
                        $("#duyuru").slideUp("slow")
                    }, 3000)
                }
            },
            error: function () {
                $("#duyuru").fadeIn("fast").html("Bilinmeyen bir hata oluştu")
                setTimeout(function () {
                    $("#duyuru").slideUp("slow")
                }, 3000)
            }
        })
    }
}