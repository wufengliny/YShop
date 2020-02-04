var now = new Date();                    //当前日期
var nowDayOfWeek = now.getDay();         //今天本周的第几天
var nowDay = now.getDate();              //当前日
var nowMonth = now.getMonth();           //当前月
var nowYear = now.getYear();             //当前年
nowYear += (nowYear < 2000) ? 1900 : 0;  //

var lastMonthDate = new Date();  //上月日期
lastMonthDate.setDate(1);
lastMonthDate.setMonth(lastMonthDate.getMonth() - 1);
var lastYear = lastMonthDate.getFullYear();
var lastMonth = lastMonthDate.getMonth();

//格式化日期：yyyy-MM-dd
function formatDate(date) {
    var myyear = date.getFullYear();
    var mymonth = date.getMonth() + 1;
    var myweekday = date.getDate();

    if (mymonth < 10) {
        mymonth = "0" + mymonth;
    }
    if (myweekday < 10) {
        myweekday = "0" + myweekday;
    }
    return (myyear + "-" + mymonth + "-" + myweekday);
}

//获得某月的天数
function getMonthDays(myMonth) {
    var monthStartDate = new Date(nowYear, myMonth, 1);
    var monthEndDate = new Date(nowYear, myMonth + 1, 1);
    var days = (monthEndDate - monthStartDate) / (1000 * 60 * 60 * 24);
    return days;
}

//获得本季度的开始月份
function getQuarterStartMonth() {
    var quarterStartMonth = 0;
    if (nowMonth < 3) {
        quarterStartMonth = 0;
    }
    if (2 < 6) {
        quarterStartMonth = 3;
    }
    if (5 < 9) {
        quarterStartMonth = 6;
    }
    if (nowMonth > 8) {
        quarterStartMonth = 9;
    }
    return quarterStartMonth;
}

function changeDate(type,formId,startDataId,endDataId) {
    var startDate = "";
    var endDate = "";
    if (type == "1") {
        //今天
        var getCurrentDate = new Date(nowYear, nowMonth, nowDay);
        var getCurrentDate = formatDate(getCurrentDate)
        startDate = getCurrentDate
        endDate = getCurrentDate;
    } else if (type == "2") {
        //昨天
        var getYesterdayDate = new Date(nowYear, nowMonth, nowDay - 1);
        var getYesterdayDate = formatDate(getYesterdayDate);
        startDate = getYesterdayDate
        endDate = getYesterdayDate;
    } else if (type == "3") {
        //昨天
        //获得本周的开始日期
        var getWeekStartDate = new Date(nowYear, nowMonth, nowDay - nowDayOfWeek);
        var getWeekStartDate = formatDate(getWeekStartDate);
        //获得本周的结束日期
        var getWeekEndDate = new Date(nowYear, nowMonth, nowDay + (6 - nowDayOfWeek));
        var getWeekEndDate = formatDate(getWeekEndDate);
        startDate = getWeekStartDate
        endDate = getWeekEndDate;
    } else if (type == "4") {
        //获得上周的开始日期
        var getUpWeekStartDate = new Date(nowYear, nowMonth, nowDay - nowDayOfWeek - 7);
        var getUpWeekStartDate = formatDate(getUpWeekStartDate);
        //获得上周的结束日期
        var getUpWeekEndDate = new Date(nowYear, nowMonth, nowDay + (6 - nowDayOfWeek - 7));
        var getUpWeekEndDate = formatDate(getUpWeekEndDate);
        startDate = getUpWeekStartDate
        endDate = getUpWeekEndDate;
    } else if (type == "5") {
        //获得本月的开始日期
        var getMonthStartDate = new Date(nowYear, nowMonth, 1);
        var getMonthStartDate = formatDate(getMonthStartDate);
        //获得本月的结束日期
        var getMonthEndDate = new Date(nowYear, nowMonth, getMonthDays(nowMonth));
        var getMonthEndDate = formatDate(getMonthEndDate);
        startDate = getMonthStartDate
        endDate = getMonthEndDate;
    } else if (type == "6") {
        //获得上月开始时间
        var getLastMonthStartDate = new Date(lastYear, lastMonth, 1);
        var getLastMonthStartDate = formatDate(getLastMonthStartDate);
        //获得上月结束时间
        var getLastMonthEndDate = new Date(lastYear, lastMonth, getMonthDays(lastMonth));
        var getLastMonthEndDate = formatDate(getLastMonthEndDate);
        startDate = getLastMonthStartDate
        endDate = getLastMonthEndDate;
    }
    startDate = startDate + " " + "00:00:00"
    endDate = endDate + " " + "23:59:59";
    $("#" + startDataId).val(startDate);
    $("#"+ endDataId).val(endDate);
    $("#"+formId).submit();
}