
var AjaxHandlerScript = "http://fe.it-academy.by/AjaxStringStorage2.php";
var UpdatePassword;
function TAjaxStorage(name) {
    var storage = {};
    var serverName = "dmitry_bilevich_online_store";
    var self = this;
    self.name = serverName;

    function init() {
        $.ajax({
            url: AjaxHandlerScript,
            type: "POST",
            data: { f: "INSERT", n: serverName, v: "" },
            cache: false,
            success: function(data) {
                if (data.error != undefined) {
                    console.log(data.error);
                } else {
                    console.log(data.result);
                }
            }
        });
    };

    this.reset = function () {

        var password = Math.random();
        $.ajax({
            url: AjaxHandlerScript,
            type: "POST",
            data: { f: "LOCKGET", n: self.name, p: password },
            cache: false,
            success: function(data) {
                if (data.error != undefined) {
                    return alert(data.error);
                }
            }
        });

        $.ajax({
            url: AjaxHandlerScript,
            type: "POST",
            data: { f: "UPDATE", n: self.name, v: "", p: password },
            cache: false,
            success: function (data) {
                if (data.result != undefined) {
                    alert(data.error)
                }
            }
        })
    };

    this.addValue = function (newData) {

        var content = {};
        var value;
        var password = Math.random();

        function LockGetDataBase(data) {
            if (data.error != undefined) {
                return console.log(data.error);

            } else {
                console.log(data.result);
            }
        };

        $.ajax({
            url: AjaxHandlerScript,
            type: "POST",
            data: { f: "LOCKGET", n: self.name, p: password },
            cache: false,
            success: LockGetDataBase
        });

        content = newData;
        value = JSON.stringify(content);

        function UpdateDataBase(data) {
            if (data.result != undefined) {
                console.log(data.result);
            } else { console.log(data.error); }

        };

        $.ajax({
            url: AjaxHandlerScript,
            type: "POST",
            data: { f: "UPDATE", n: self.name, v: value, p: password },
            cache: false,
            success: UpdateDataBase
        })

    };

    this.getValue = function () {
        var content = {};

        function ReadDataBase(data) {
            if (data.error != undefined) {
                console.log(data.error);
            } else {
                content = JSON.parse(data.result);
            }
        };
        $.ajax({
            url: AjaxHandlerScript,
            type: "POST",
            data: { f: "READ", n: self.name },
            cache: false,
            success: ReadDataBase,
            async: false

        })
        return content;
    };

    init();
}