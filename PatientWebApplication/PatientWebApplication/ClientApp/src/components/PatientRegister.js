"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_redux_1 = require("react-redux");
var CounterStore = require("../store/Counter");
var Header_1 = require("./Header");
var RegisterPatient_1 = require("./RegisterPatient");
var PatientRegistration = /** @class */ (function (_super) {
    __extends(PatientRegistration, _super);
    function PatientRegistration() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    PatientRegistration.prototype.render = function () {
        return (React.createElement(React.Fragment, null,
            React.createElement(Header_1.default, { title: "Register", description: "Registration for patient" }),
            React.createElement(RegisterPatient_1.default, null)));
    };
    return PatientRegistration;
}(React.PureComponent));
;
exports.default = react_redux_1.connect(function (state) { return state.counter; }, CounterStore.actionCreators)(PatientRegistration);
//# sourceMappingURL=PatientRegister.js.map