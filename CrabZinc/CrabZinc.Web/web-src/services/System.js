﻿import VueConfig from "services/VueCommon.js"
import "services/CustomDirectives.js"

class System {
    constructor() {        
        this._baseUrl = ($("#rootPathPrefix").val() || "") + "/";
        this._events = new Vue();

        VueConfig();
    }

    get events() {
        return this._events;
    }

    get baseUrl() {
        return this._baseUrl;
    }
}

export default new System();