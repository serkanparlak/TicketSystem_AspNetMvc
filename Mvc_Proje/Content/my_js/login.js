
$(document).ready(function () {
    $("#btn-giris").click(function () {
        var veri = $("form").serializeArray()
        var bosmu = false;
        $.each(veri, function (i, field) {
            if (field.value == "") {
                $("#login-mesaj").fadeIn("slow").html("Boş alanları doldurunuz")
                bosmu = true;
                setTimeout(function () {
                    $("#login-mesaj").slideUp("fast")
                }, 3000)
            }
        })
        if (!bosmu) {
            $.ajax({
                type: 'POST',
                data: veri,
                url: '/Home/Login',
                success: function (result) {
                    if (result == "Admin") {
                        location.href = "/Admin/Index"
                    }
                    else if (result == "Kullanıcı") {
                        location.href = "/User/Index"
                    }
                    else {
                        $("#login-mesaj").fadeIn("slow").html("Kullanıcı veya şifre yanlış")
                        setTimeout(function () {
                            $("#login-mesaj").slideUp("fast")
                        }, 3000)
                    }
                }
            })
        }
    });
});
