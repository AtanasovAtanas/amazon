import React, { useEffect } from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import HomePage from "./pages/home";
import LoginPage from "./pages/login";
import RegisterPage from "./pages/register";
import { useGlobalContext } from "./context/context";
import identityService from "./services/identity";

const Navigator = () => {
	const { login } = useGlobalContext();

	useEffect(() => {
		identityService.getIdentityDetails(
			(response) =>
				login(
					{ email: response.email, userId: response.userId },
					response.token
				),
			() => console.log("failure")
		);
	}, []);

	return (
		<Router>
			<Switch>
				<Route exact path="/">
					<HomePage />
				</Route>
				<Route exact path="/login">
					<LoginPage />
				</Route>
				<Route exact path="/register">
					<RegisterPage />
				</Route>
			</Switch>
		</Router>
	);
};

export default Navigator;
