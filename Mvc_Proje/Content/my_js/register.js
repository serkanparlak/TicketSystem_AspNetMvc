/*Kullanıcı kontrol*/
$(document).ready(function () {
    $("#KullaniciAdi").blur(function () {
        var kul = $(this).val()
        if (kul != "") {
            $.ajax({
                type: 'POST',
                url: '/Home/KullaniciKontrolEt?kullaniciAdi=' + kul,
                success: function (sonuc) {
                    if (sonuc) {
                        $("#KullaniciAdi").css("border-color", "red")
                    }
                    else {
                        $("#KullaniciAdi").css("border-color", "#00ff90")
                    }
                },
                error: function () {

                }
            })
        }
        else {
            $(this).css("border-color", "#ccc")
        }
    })
})

/*Email kontrol*/
$(document).ready(function () {
    $("#Mail").blur(function () {
        var mail = $(this).val();
        if (mail != "") {
            $.ajax({
                type: 'POST',
                url: '/Home/EmailKontrolEt?gelenMail=' + mail,
                success: function (sonuc) {
                    if (sonuc) {
                        $("#Mail").css("border-color", "red")
                    }
                    else {
                        $("#Mail").css("border-color", "#00ff90")
                    }
                }
            })
        }
        else $("#Mail").css("border-color", "#ccc")
    })
})


$(document).ready(function () {
    $("#pass2").blur(function () {
        var ps1 = $("#Sifre").val();
        var ps2 = $("#pass2").val();
        if (ps1 != "" & ps2 != "") {
            if (ps1 != ps2) {
                $(this).css("border-color", "red")
                $("#Sifre").css("border-color", "red")
            }
            else {
                $(this).css("border-color", "#00ff90")
                $("#Sifre").css("border-color", "#00ff90")
            }
        }
        else {
            $(this).css("border-color", "#ccc")
            $("#Sifre").css("border-color", "#ccc")
        }

    })
})


$(document).ready(function () {
    $("#Sifre").blur(function () {
        var ps1 = $("#Sifre").val();
        var ps2 = $("#pass2").val();
        if (ps1 != "" & ps2 != "") {
            if (ps1 != ps2) {
                $("#pass2").css("border-color", "red")
                $("#Sifre").css("border-color", "red")
            }
            else {
                $("#pass2").css("border-color", "#00ff90")
                $("#Sifre").css("border-color", "#00ff90")
            }
        }
        else {
            $("#pass2").css("border-color", "#ccc")
            $("#Sifre").css("border-color", "#ccc")
        }

    })
})

function Kayit() {
    var isim = $("#Ad_Soyad").val()
    if (isim == "") var i = true;
    else i = false;
    var kullanici = $("#KullaniciAdi").css("border-color")
    if (kullanici == "rgb(204, 204, 204)") var k = true;
    else k = false;
    var mail = $("#Mail").css("border-color")
    if (mail == "rgb(204, 204, 204)") var e = true;
    else e = false;
    var sifre = $("#Sifre").css("border-color")
    if (sifre == "rgb(204, 204, 204)") var s = true;
    else s = false;
    var gun = $("#day").val();
    var ay = $("#month").val();
    var yil = $("#year").val();
    //if (i == true | k == true | e == true | s == true | gun == "Seçiniz" | ay == "Seçiniz" | yil == "Seçiniz") {
    if (i | k | e | s | gun == "Seçiniz" | ay == "Seçiniz" | yil == "Seçiniz") {
        $("#eksik-mesaj").slideDown("fast");
        setTimeout(function () {
            $("#eksik-mesaj").slideUp("slow")
        }, 3000)
    }
    else {
        $("#Dogum").val($("#day").val() + "." + $("#month").val() + "." + $("#year").val())
        var datacik = $("form").serializeArray();
        $.ajax({
            url: '/Home/Register',
            method: 'POST',
            data: datacik,
            success: function (sonuc) {
                if (sonuc) {
                    if (confirm("Kayıt başarılı Giriş sayfasına yönlendirilmek istermisiniz ?"))
                        location.href = "/Home/Login"
                }
                else
                    return confirm("Kayıt başarısız oldu");

            },
            error: function () {
                return confirm("Anlaşılamayan bir hata oluştu")
            }
        })
    }
}