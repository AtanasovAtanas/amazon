import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import Navigator from "./navigation";
import "./index.css";

ReactDOM.render(
	<React.StrictMode>
		<App>
			<Navigator />
		</App>
	</React.StrictMode>,
	document.getElementById("root")
);
