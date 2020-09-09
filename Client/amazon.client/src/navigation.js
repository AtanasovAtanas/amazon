import React, { useEffect } from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import HomePage from "./pages/home";
import LoginPage from "./pages/login";
import RegisterPage from "./pages/register";
import { useGlobalContext } from "./context/context";
import identityService from "./services/identity";
import categoriesService from "./services/category";
import * as DispatchTypes from "./context/constants";

const Navigator = () => {
	const { login, dispatch } = useGlobalContext();

	useEffect(() => {
		const fetchData = async () => {
			await identityService.getIdentityDetails(
				(response) =>
					login(
						{ email: response.email, userId: response.userId },
						response.token
					),
				() => console.log("failure")
			);

			await categoriesService.getAll(
				(response) =>
					dispatch({
						type: DispatchTypes.FETCH_CATEGORIES,
						payload: response,
					}),
				() => console.log("fetching categories has failed")
			);
		};

		fetchData();
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
