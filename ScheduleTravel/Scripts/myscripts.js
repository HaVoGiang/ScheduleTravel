

var dataArr = [];
var data = [];
var listData = $("#list-data li");
for (i = 0; i < listData.length; i++) {
    dataArr.push($("li[data-id=" + listData[i].dataset.id + "]").data());
}

var dayNum = 9;
var dataDayArr = new Array();
var sum = 0, k = 0,oldDay = 0;
for (i = 0; i < dayNum; i++) {
    var arrTemp = [];
    for (j = k; j < dataArr.length; j++) {
        sum += dataArr[j].timein;
        if (sum > 13 || dataArr[j].sortbyday != oldDay) {
            k = j;
            sum = 0;
            oldDay = dataArr[j].sortbyday;
            break;
        } else {
            k++;
            dataArr[j].sortbyday = i;
            arrTemp.push(dataArr[j]);
        }
    }
    dataDayArr.push(arrTemp);
}

UpdateData(dataDayArr, 8);
function UpdateData(data, timestartContainer) {
    for (i = 0; i < data.length; i++) {
        for (j = 0; j < data[i].length; j++) {
            if (j == 0) {
                data[i][0].timestart = timestartContainer;
                data[i][0].timein = parseInt($("li[data-id=" + data[i][j].id + "] > .txtTimeIn").val());
            } else {
                data[i][j].timestart = data[i][j - 1].timestart + data[i][j - 1].timein;
                data[i][j].timein = parseInt($("li[data-id=" + data[i][j].id + "] > .txtTimeIn").val());
            }
            data[i][j].sortbyday = i;
        }
    }
    dataDayArr = data;
}





$('#sort-table').empty();
for (i = 0; i < dataDayArr.length; i++) {
    $('#sort-table').append("<ol class='serialization vertical olid" + i + "'></ol>");
    for (j = 0; j < dataDayArr[i].length; j++) {
        $('.olid' + i).append("<li data-id=\"" + dataDayArr[i][j].id + "\" data-tourid=\"" + dataDayArr[i][j].tourid + "\" data-scheduleid=\"" + dataDayArr[i][j].scheduleid + "\" data-sortbyday=\"" + dataDayArr[i][j].sortbyday + "\" data-title=\"" + dataDayArr[i][j].title + "\" data-timestart=\"" + dataDayArr[i][j].timestart + "\" data-timein=\"" + dataDayArr[i][j].timein + "\" data-timefree=\"" + dataDayArr[i][j].timefree + "\">Nơi đến: " + dataDayArr[i][j].title + ", Thời gian bắt đầu: <input class = \"txtTimeStart\" style=\"width: 40px;\" type=\"number\" value=\"" + dataDayArr[i][j].timestart + "\">h, Thời gian lưu trú: <input class = \"txtTimeIn\" style=\"width: 40px;\" type=\"number\" value=\"" + dataDayArr[i][j].timein + "\">h <button onClick = \"btnSubmit(" + i + "," + j + ")\" type=\"button\">Ok</button></li>");
    }
}
var group = $("ol.serialization").sortable({
    group: 'serialization',
    onDrop: function ($item, container, _super) {
        data = group.sortable("serialize").get();
        if (!checkData(data)) {
            Refresh();
            return;
        }
        UpdateData(data, 8);
        LoadView(data);
        UpdateDB();
        _super($item, container);
    }
});

function checkData(data) {
    for (i = 0; i < data.length; i++) {
        let sumData = 0;
        for (j = 0; j < data[i].length; j++) {
            sumData += data[i][j].timein;
            if (sumData > 13) {
                alert("Không đủ thời gian trong ngày!");
                return false;
            }
        }
    }
    return true;
}
function Refresh() {
    for (i = 0; i < dataDayArr.length; i++) {
        $('.olid' + i).empty();
        for (j = 0; j < dataDayArr[i].length; j++) {
            $('.olid' + i).append("<li data-id=\"" + dataDayArr[i][j].id + "\" data-tourid=\"" + dataDayArr[i][j].tourid + "\" data-scheduleid=\"" + dataDayArr[i][j].scheduleid + "\" data-sortbyday=\"" + dataDayArr[i][j].sortbyday + "\" data-title=\"" + dataDayArr[i][j].title + "\" data-timestart=\"" + dataDayArr[i][j].timestart + "\" data-timein=\"" + dataDayArr[i][j].timein + "\" data-timefree=\"" + dataDayArr[i][j].timefree + "\">Nơi đến: " + dataDayArr[i][j].title + ", Thời gian bắt đầu: <input class = \"txtTimeStart\" style=\"width: 40px;\" type=\"number\" value=\"" + dataDayArr[i][j].timestart + "\">h, Thời gian lưu trú: <input class = \"txtTimeIn\" style=\"width: 40px;\" type=\"number\" value=\"" + dataDayArr[i][j].timein + "\">h <button onClick = \"btnSubmit(" + i + "," + j + ")\" type=\"button\">Ok</button></li>");
        }
    }
}
function LoadView(data) {
    for (i = 0; i < data.length; i++) {
        for (j = 0; j < data[i].length; j++) {
            var rs = "Nơi đến: " + dataDayArr[i][j].title + ", Thời gian bắt đầu: <input class = \"txtTimeStart\" style=\"width: 40px;\" type=\"number\" value=\"" + dataDayArr[i][j].timestart + "\">h, Thời gian lưu trú: <input class = \"txtTimeIn\" style=\"width: 40px;\" type=\"number\" value=\"" + dataDayArr[i][j].timein + "\">h <button onClick = \"btnSubmit(" + i + "," + j + ")\" type=\"button\">Ok</button>"
            $("li[data-id=" + dataDayArr[i][j].id + "]").html(rs);
        }
    }
}

function btnSubmit(a, b) {
    data = group.sortable("serialize").get();
    for (i = a; i < data.length; i++) {
        for (j = b; j < data[i].length; j++) {
            if (i === a && j === b) {
                data[i][j].timestart = parseInt($("li[data-id=" + data[i][j].id + "] > .txtTimeStart").val());
                data[i][j].timein = parseInt($("li[data-id=" + data[i][j].id + "] > .txtTimeIn").val());
            } else {
                if (j !== 0) {
                    data[i][j].timestart = data[i][j - 1].timestart + data[i][j - 1].timein;
                    data[i][j].timein = parseInt($("li[data-id=" + data[i][j].id + "] > .txtTimeIn").val());
                }
            }
            data[i][j].sortbyday = i;
            var rs = "Nơi đến: " + data[i][j].title + ", Thời gian bắt đầu: <input class = \"txtTimeStart\" style=\"width: 40px;\" type=\"number\" value=\"" + data[i][j].timestart + "\">h, Thời gian lưu trú: <input class = \"txtTimeIn\" style=\"width: 40px;\" type=\"number\" value=\"" + data[i][j].timein + "\">h <button onClick = \"btnSubmit(" + i + "," + j + ")\" type=\"button\">Ok</button>"
            $("li[data-id=" + data[i][j].id + "]").html(rs);
        }
        break;
    }

    if (!checkData(data)) {
        Refresh();
        return;
    }
    dataDayArr = data;
    UpdateDB();
}

function UpdateDB() {
    let data = [];
    for (i = 0; i < dataDayArr.length; i++) {
        for (j = 0; j < dataDayArr[i].length; j++) {
            data.push(dataDayArr[i][j]);
        }
    }
    $.ajax({
        url: '/TourShedules/UpdateData',
        dataType: "json",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data, null, ''),
        traditional: true,
        success: function (datareponse) {
            console.log(datareponse);
        },
        error: function (xhr) {
            alert('error');
        }

    });
}