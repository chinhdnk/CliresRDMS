class Translate {
    constructor(attribute, lang, page, layout) {
        this.attribute = attribute;
        this.lang = lang;
        this.page = page;
        this.layout = layout;
        this.msgLabels = {};
    }

    process = async () => {
        let url = "/resources/" + this.lang + "_system.json";
        try {
            const response = await fetch(url);
            const responseAsJson = await response.json();

            if (response.status === 200 && response.ok) {
                let LngPage = responseAsJson[this.page];
                let LngLayout = responseAsJson[this.layout];
                /* Merge defaults and options, without modifying defaults */
                this.msgLabels = $.extend({}, LngPage, LngLayout);

                var allDom = document.getElementsByTagName("*");
                for (let i = 0; i < allDom.length; i++) {
                    let elem = allDom[i];
                    let key = elem.getAttribute(this.attribute);
                    if (key != null) {
                        //Set placeholder for input
                        if (elem.tagName == "INPUT") {
                            elem.setAttribute('placeholder', this.msgLabels[key]);
                        } else if (elem.tagName == "IMG") {
                            elem.setAttribute('alt', _self.msgLabels[key]);
                        } else if (elem.tagName == "SELECT") {
                            elem.setAttribute('data-placeholder', this.msgLabels[key]);
                        } else {
                            elem.innerHTML = this.msgLabels[key];
                        }
                    }
                }
            } else {
                console.log('request error...' + response.statusText);
            }
        } catch (error) {
            console.log('Looks like there was a problem: \n', error);
        }
    }

    getLabel = async () => {
        let url = "/resources/" + this.lang + "_system.json";
        let LngPage = {};
        try {
            const response = await fetch(url);
            const responseAsJson = await response.json();
            if (response.status === 200 && response.ok) {
                LngPage = responseAsJson[this.page];
            } else {
                console.log('request error...' + response.statusText);
            }
        } catch (error) {
            console.log('Looks like there was a problem: \n', error);
        }
        return LngPage;
    }
}
