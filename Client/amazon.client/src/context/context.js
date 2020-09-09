import React, { createContext, useReducer, useContext } from "react";
import { GlobalReducer } from "./reducer";
import * as DispatchTypes from "./constants";

const initialState = {
	user: { userId: "", email: "" },
	isLoggedIn: false,
	categories: [],
};

export const GlobalContext = createContext(initialState);

export const GlobalProvider = ({ children }) => {
	const [state, dispatch] = useReducer(GlobalReducer, initialState);

	const login = (user, token) => {
		dispatch({
			type: DispatchTypes.LOGIN,
			payload: { user, token },
		});
	};

	const logout = () => {
		dispatch({
			type: DispatchTypes.LOGOUT,
			payload: null,
		});
	};

	return (
		<GlobalContext.Provider value={{ ...state, login, logout, dispatch }}>
			{children}
		</GlobalContext.Provider>
	);
};

export const useGlobalContext = () => useContext(GlobalContext);
