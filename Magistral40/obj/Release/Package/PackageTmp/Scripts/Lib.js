var check = true;
$(document).ready(function () {
    $("#prodMenu").click(function () {
        if (check) {
            $("#prodMenu").animate({ left: 130 }, 500);
            $(".vert_menu").animate({ left: 305 }, 450);
            $(".contentM").animate({ "margin-left": "200px" }, 500);
            $('body,html').animate({ scrollTop: 0 }, 400); 
            check = false;
        }
        else {
            $(".vert_menu").animate({ left: 0 }, 500);
            $("#prodMenu").animate({ left: "-3.55em" }, 450);
            $(".contentM").animate({ "margin-left": "0px" }, 500);
            check = true;
        }
   /* }, function () {
        $(".vert_menu").animate({ left: 0 }, 500);*/
    });
    
    $("#prodInfo1").click(function () {
        if (check) {
            $("#prodInfo1").animate({ left: "8.8em" }, 450);
            $(".vert_menu").animate({ left: 305 }, 400);
            $(".contentM").animate({ "margin-left": "200px" }, 500);
            $('body,html').animate({ scrollTop: 0 }, 400); 
            check = false;
        }
        else {
            $(".vert_menu").animate({ left: 0 }, 450);
            $("#prodInfo1").animate({ left: "-2.1em" }, 400);
            $(".contentM").animate({ "margin-left": "0px" }, 500);
            check = true;
        }
        /* }, function () {
             $(".vert_menu").animate({ left: 0 }, 500);*/
    });

    $("#close_myModal").click(function () { $("input#UserName").val(""); $("textarea#Message").val(""); $("input#Phone").val(""); $("input#EmailAdrress").val(""); $("input#Phone").css({ 'border-top': '3px solid #b5b5b5' }); $("input#EmailAdrress").css({ 'border-top': '3px solid #b5b5b5' }); }); $(function () { $('.navbar-nav li').click(function () { $(this).siblings().removeClass('active'); $(this).addClass('active'); }); }); $("#SentMes").click(function () { var userName = $("input#UserName").val(); var message = $("textarea#Message").val(); var phone = $("input#Phone").val(); var emailAdrress = $("input#EmailAdrress").val(); var z = { UserName: userName, Message: message, Phone: phone, EmailAdrress: emailAdrress }; $.post("/Home/ASMessage", z, function (res) { if (res.isAdded) { $("#myModal").modal('hide'); $("input#UserName").val(""); $("textarea#Message").val(""); $("input#Phone").val(""); $("input#EmailAdrress").val(""); $("input#Phone").css({ 'border-top': '3px solid #b5b5b5' }); $("input#EmailAdrress").css({ 'border-top': '3px solid #b5b5b5' }); ModalGood(); } else { if (res.isPhone != "") $("input#Phone").css({ 'border-top': '4px solid #ff0000' }); else $("input#Phone").css({ 'border-top': '3px solid #b5b5b5' }); if (res.isEmail != "") $("input#EmailAdrress").css({ 'border-top': '4px solid #ff0000' }); else $("input#EmailAdrress").css({ 'border-top': '3px solid #b5b5b5' }); } }, "json") });
}); function isValidEmailAddress(emailAddress) { var pattern = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i); return pattern.test(emailAddress); } function SentForm() { var userName = $("input#NameF").val(); var phone = $("input#PhoneF").val(); var emailAdrress = $("input#EmailF").val(); var z = { UserName: userName, Phone: phone, EmailAdrress: emailAdrress }; $.post("/Home/MessIndex", z, function (res) { if (res.isAdded) { $("input#NameF").val(""); $("input#PhoneF").val(""); $("input#EmailF").val(""); ModalGood(); $("input#PhoneF").css({ 'border-top': '3px solid #b5b5b5' }); $("input#EmailF").css({ 'border-top': '3px solid #b5b5b5' }); } else { ModalBed(res.isPhone, res.isEmail); if (res.isPhone != "") $("input#PhoneF").css({ 'border-top': '4px solid #ff0000' }); else $("input#PhoneF").css({ 'border-top': '3px solid #b5b5b5' }); if (res.isEmail != "") $("input#EmailF").css({ 'border-top': '4px solid #ff0000' }); else $("input#EmailF").css({ 'border-top': '3px solid #b5b5b5' }); } }, "json") } function ModalGood() { $("#ModalInfo h4").text("Спасибо за вашу заявку!"); $("#ModalInfo p").text("Наш менеджер свяжется с вами в ближайшее время."); $("#ModalInfo .modal-dialog .modal-content").css({ 'background-color': '#4d9023' }); $("#ModalInfo div.modal-header").css({ 'background-color': '#42791f', 'border-bottom': '1px solid #e7f3d9' }); $("#ModalInfo").modal('show'); setTimeout(function () { $("#ModalInfo").modal('hide'); }, 2500); } function SentTwo() {
    var phone = $("input#PhoneF1").val(); var z = { Phone: phone }; $.post("/Home/MessFon", z, function (res) {
        if (res.isAdded) {
            $("input#PhoneF1").val("")
$("input#PhoneF1").css({'border-top':'3px solid #5b5b5b'});ModalGood();}else{$("input#PhoneF1").css({'border-top':'4px solid #ff0000'});ModalBed(res.isPhone,"");}},"json")}function ModalBed(phone,email){$("#ModalInfo h4").text("Предупреждение: сообщение не было отправлено!");if(phone!="")$("#ModalInfo p").html(phone+"</br>"+email);else $("#ModalInfo p").html(email);$("#ModalInfo .modal-dialog .modal-content").css({'background-color':'#bd3538'});$("#ModalInfo div.modal-header").css({'background-color':'#9b2d30','border-bottom':'1px solid #e7f3d9'});$("#ModalInfo").modal('show');setTimeout(function(){$("#ModalInfo").modal('hide');},3500);}(function(d,w,c){(w[c]=w[c]||[]).push(function(){try{w.yaCounter45931650=new Ya.Metrika({id:45931650,clickmap:true,trackLinks:true,accurateTrackBounce:true,webvisor:true,trackHash:true});}catch(e){}});var n=d.getElementsByTagName("script")[0],s=d.createElement("script"),f=function(){n.parentNode.insertBefore(s,n);};s.type="text/javascript";s.async=true;s.src="https://mc.yandex.ru/metrika/watch.js";if(w.opera=="[object Opera]"){d.addEventListener("DOMContentLoaded",f,false);}else{f();}})(document,window,"yandex_metrika_callbacks");
