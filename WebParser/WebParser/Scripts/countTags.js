
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

    var sortedAllTags = [];
    var prop;
    for (prop in tags) {
        if (tags.hasOwnProperty(prop)) {
            sortedAllTags.push({
                'key': prop,
                'value': tags[prop]
            });
        }
    }
    sortedAllTags.sort(function (a, b) {
        return b.value - a.value;
    });
    var counter = 0;
    var sortedTopTags = [];
    for (var sortedTag in sortedAllTags) {
        if (sortedAllTags.hasOwnProperty(sortedTag))
        {
            sortedTopTags.push(sortedAllTags[sortedTag]);
            if (counter === 9) break;
            counter++;
        }
    }

    var html = "<table border='1|1'>";
    for (var finalTag in sortedTopTags) {
        if (sortedAllTags.hasOwnProperty(finalTag)) {
            html += "<tr>";
            html += "<td>" + sortedTopTags[finalTag].key + "</td>";
            html += "<td>" + sortedTopTags[finalTag].value + "</td>";
        }
    }
    html += "</table>";
    document.getElementById("TopHtml").innerHTML = html;
}


