var ilk_kul = $("#KullaniciAdi").val();

function success(myresult) {
    if (myresult.IsSuccess) {
        var kadi = $("#KullaniciAdi").val();
        $("#mesage").fadeIn("fast")
        setTimeout(function () {
            $("#mesage").slideUp("slow")
        }, 3000)
        if (ilk_kul != kadi & myresult.Mesaj != "Admin") {
            ilk_kul = kadi;
            $.ajax({
                method: 'POST',
                url: '/Home/KullaniciDegisti?kadi='+ kadi
            })
        }
    }
    else {
        $("#mesage").text(myresult.Mesaj)
        $("#mesage").removeClass("alert-info")
        $("#mesage").addClass("alert-danger")
        $("#mesage").fadeIn("fast")
        setTimeout(function () {
            $("#mesage").slideUp("slow")
        }, 3000)
    }
}
function fail() {
    alert("Bir hata oluştu")
}


var yeniKullanici = true;
var yeniEmail = true;
/*Kullanıcı kontrol*/

$(document).ready(function () {
    $("#KullaniciAdi").blur(function () {
        var kul = $(this).val()
        if (kul != "") {
            $.ajax({
                type: 'POST',
                url: '/Home/KullaniciKontrolEt?kullaniciAdi=' + kul,
                success: function (sonuc) {
                    if (sonuc & kul != ilk_kul) {
                        $("#KullaniciAdi").css("border-color", "red")
                        yeniKullanici = false;
                    }
                    else {
                        $("#KullaniciAdi").css("border-color", "#00ff90")
                        yeniKullanici = true;
                    }
                }
            })
        }
        else {
            $(this).css("border-color", "#ccc")
        }
    })
})

/*Email kontrol*/
var ilk_mail = $("#Mail").val();

$(document).ready(function () {
    $("#Mail").blur(function () {
        var mail = $(this).val();
        if (mail != "") {
            $.ajax({
                type: 'POST',
                url: '/Home/EmailKontrolEt?gelenMail=' + mail,
                success: function (sonuc) {
                    if (sonuc & mail != ilk_mail) {
                        $("#Mail").css("border-color", "red")
                        yeniEmail = false;
                    }
                    else {
                        $("#Mail").css("border-color", "#00ff90")
                        yeniEmail = true;
                    }
                }
            })
        }
        else {
            $(this).css("border-color", "#ccc")
        }
    })

    $("#kayitform").submit(function () {
        if (!yeniEmail | !yeniKullanici) {
            return false;
        }
    })
})