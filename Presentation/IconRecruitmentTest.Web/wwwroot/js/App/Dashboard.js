function LoadDashboardData() {
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);
    google.charts.setOnLoadCallback(drawBarChart);
}
function drawChart() {
    var dataMode = [];
    dataMode.push(['Company', 'Number of orders']);
    Object.keys(companyOrderData).forEach(function (key) {
        dataMode.push([companyOrderData[key].companyName + " (" + companyOrderData[key].numberOfOrders + ")", companyOrderData[key].numberOfOrders]);
    });
    var data = google.visualization.arrayToDataTable(dataMode);

    var titleOrderTxt = (!jQuery.isEmptyObject(LogisticsCompany.State.ResourceObject)) ? LogisticsCompany.State.ResourceObject.ShippingActivitiesBasedOnNumberOfOrders : titleOrder;
    var options = {
        title: titleOrderTxt,
        pieHole: 0.4,
    };
    var chart = new google.visualization.PieChart(document.getElementById('activitiesBasedOnOrder'));
    chart.draw(data, options);
}

function drawBarChart() {
    var dataMode = [];

    var lblInfoPriceTxt = (!jQuery.isEmptyObject(LogisticsCompany.State.ResourceObject)) ? LogisticsCompany.State.ResourceObject.TotalPrice : lblInfoPrice;

    dataMode.push(['Company', lblInfoPriceTxt + ' €']);
    Object.keys(companyOrderData).forEach(function (key) {
        dataMode.push([companyOrderData[key].companyName, companyOrderData[key].totalPrice]);
    });
    var data = google.visualization.arrayToDataTable(dataMode);

    var titlePriceTxt = (!jQuery.isEmptyObject(LogisticsCompany.State.ResourceObject)) ? LogisticsCompany.State.ResourceObject.ShippingActivitiesBasedOnTotalPrice : titlePrice;

    var options = {
        title: titlePriceTxt,
        pieHole: 0.4,
    };
    var chart = new google.visualization.BarChart(document.getElementById('activitiesBasedOnTotalPrice'));
    chart.draw(data, options);
}
$(document).ready(function () {
    try {
        LoadDashboardData();
    } catch (ex) {
        Helper.log(ex);
    }
});

