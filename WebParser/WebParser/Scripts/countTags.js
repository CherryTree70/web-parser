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
    sortObject(tags);

}
function sortObject(obj) {
    var arr = [];
    var prop;
    for (prop in obj) {
        if (obj.hasOwnProperty(prop)) {
            arr.push({
                'key': prop,
                'value': obj[prop]
            });
        }
    }
    arr.sort(function (a, b) {
        return b.value - a.value;
    });
    var counter = 0;
    var tmp = [];
    for (var k in arr) {
        if (arr.hasOwnProperty(k))
        {
            tmp.push(arr[k]);
            if (counter === 9) break;
            counter++;
        }
        
        
    }
    var e;
    var html = "<table border='1|1'>";
    for (e in tmp) {
        if (arr.hasOwnProperty(e)) {
            html += "<tr>";
            html += "<td>" + tmp[e].key + "</td>";
            html += "<td>" + tmp[e].value + "</td>";
        }
        
        
    }

    html += "</table>";
    document.getElementById("TopHtml").innerHTML = html;
    
    
    
   
    

}





