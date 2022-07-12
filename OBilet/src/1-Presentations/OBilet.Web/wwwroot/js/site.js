var dateToday = new Date();
$(function () {
    $("#drpBusOrigin").select2();
    $("#drpBusDestination").select2();

    $("#travelDate").datepicker({
        dateFormat: "dd-mm-yy",
        autoSize: true,
        changeMonth: true,
        changeYear: false,
        dayNames: ["pazar", "pazartesi", "salı", "çarşamba", "perşembe", "cuma", "cumartesi"],
        dayNamesMin: ["pa", "pzt", "sa", "çar", "per", "cum", "cmt"],
        monthNamesShort: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
        nextText: "ileri",
        prevText: "geri",
        showAnim: "drop",
        minDate: dateToday,
        defaultDate: +1,
        yearRange: "2022:2022"
    });

    $("#travelDate").datepicker("setDate", "+1");
});

function setDateToday() {
    $("#travelDate").datepicker("setDate", "+0");

}

function setDateTomorrow() {
    $("#travelDate").datepicker("setDate", "+1");
}

function changeOriginAndDestination() {
    const originId = document.getElementById("drpBusOrigin").value;
    const destinationId = document.getElementById("drpBusDestination").value;

    $("#drpBusOrigin").val(destinationId);
    $("#drpBusDestination").val(originId);
    $("#drpBusOrigin").change();
    $("#drpBusDestination").change();
}
