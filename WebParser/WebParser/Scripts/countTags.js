function countHtmlTags() {
    var key;
    var stringWebParser = document.getElementById("Content").textContent;
    var tag;
    var tags = [];
    var tmp = [];
    var parser = new DOMParser();
    var domWebParser = parser.parseFromString(stringWebParser, "text/html");
    domWebParser.querySelectorAll('*').forEach(function (node) {
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
    for (var k in arr) {
        var q = arr[k];
        document.write(q.key, q.value);
        if (counter === 9) break;
        counter++;
        
    }
  
}





