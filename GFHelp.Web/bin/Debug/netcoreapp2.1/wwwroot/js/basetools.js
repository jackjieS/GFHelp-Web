function setValueToStorage(value0,value1){
    localStorage.setItem(value0,value1);
}
function getValueFromStorage(value){
    return  localStorage.getItem(value);
}    
function logout() {
    setCookie('token', null);
    window.location.href = 'login.html';
}
function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=")
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1
            c_end = document.cookie.indexOf(";", c_start)
            if (c_end == -1) c_end = document.cookie.length
            return unescape(document.cookie.substring(c_start, c_end))
        }
    }
    return ""
}
function getHost() {
        return '127.0.0.1';
}



function checkCookie() {
    username = getCookie('username')
    if (username != null && username != "") { alert('Welcome again ' + username + '!') } else {
        username = prompt('Please enter your name:', "")
        if (username != null && username != "") {
            setCookie('username', username, 365)
        }
    }
}


function setCookie(c_name, value, expiredays) {
  var exdate = new Date()
  exdate.setDate(exdate.getDate() + expiredays)
  document.cookie = c_name + "=" + escape(value) +
      ((expiredays == null) ? "" : ";expires=" + exdate.toGMTString())
}
function formatSeconds(value) {
    var secondTime = parseInt(value);// 秒
    var minuteTime = 0;// 分
    var hourTime = 0;// 小时
    var stringHour;
    var stringMinute;
    var stringSecond;
    if (secondTime > 60) {//如果秒数大于60，将秒数转换成整数
        //获取分钟，除以60取整数，得到整数分钟
        minuteTime = parseInt(secondTime / 60);
        //获取秒数，秒数取佘，得到整数秒数
        secondTime = parseInt(secondTime % 60);
        //如果分钟大于60，将分钟转换成小时
        if (minuteTime > 60) {
            //获取小时，获取分钟除以60，得到整数小时
            hourTime = parseInt(minuteTime / 60);
            //获取小时后取佘的分，获取分钟除以60取佘的分
            minuteTime = parseInt(minuteTime % 60);
        }
    }
    if (hourTime < 10) {
        stringHour = "0" + hourTime.toString();
    }
    else {
        stringHour = hourTime.toString();
    }
    if (minuteTime < 10) {
        stringMinute = "0" + minuteTime.toString();
    }
    else {
        stringMinute = minuteTime.toString();
    }
    if (secondTime < 10) {
        stringSecond = "0" + secondTime.toString();
    }
    else {
        stringSecond = secondTime.toString();
    }
    return result = stringHour + ":" + stringMinute + ":" + stringSecond;



}
function getDefaultStyle(obj,attribute){ // 返回最终样式函数，兼容IE和DOM，设置参数：元素对象、样式特性   
    return obj.currentStyle?obj.currentStyle[attribute]:document.defaultView.getComputedStyle(obj,false)[attribute];   
    }
