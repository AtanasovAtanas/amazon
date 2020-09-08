import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import HomePage from "./pages/home";

const Navigator = () => {
	return (
		<Router>
			<Switch>
				<Route exact path="/">
					<HomePage />
				</Route>
			</Switch>
		</Router>
	);
};

export default Navigator;
