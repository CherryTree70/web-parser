
function countHtmlTags() {

    var stringWebParser = document.getElementById("Content").textContent;
    var tag;
    var tags = [];
    var parser = new DOMParser();
    var domWebParser = parser.parseFromString(stringWebParser, "text/html");
    domWebParser.querySelectorAll("*").forEach(function (node) {
        tag = node.tagName.toLowerCase();
        if (!tags[tag]) {
        tags[tag] = 1;
        } else {
        tags[tag]++;
        }
    });

    var arr = [];
    var prop;
    for (prop in tags) {
        if (tags.hasOwnProperty(prop)) {
            arr.push({
                'key': prop,
                'value': tags[prop]
            });
        }
    }
    arr.sort(function (a, b) {
        return b.value - a.value;
    });
    var counter = 0;
    var tmp = [];
    for (var sortedTag in arr) {
        if (arr.hasOwnProperty(sortedTag))
        {
            tmp.push(arr[sortedTag]);
            if (counter === 9) break;
            counter++;
        }
        
        
    }
    var html = "<table border='1|1'>";
    for (var finalTag in tmp) {
        if (arr.hasOwnProperty(finalTag)) {
            html += "<tr>";
            html += "<td>" + tmp[finalTag].key + "</td>";
            html += "<td>" + tmp[finalTag].value + "</td>";
        }
        
        
    }
    html += "</table>";
    document.getElementById("TopHtml").innerHTML = html;
}


