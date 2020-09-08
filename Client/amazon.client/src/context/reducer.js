import * as DispatchTypes from "./constants";

export const GlobalReducer = (state, action) => {
	switch (action.type) {
		case DispatchTypes.LOGIN:
			const { user, token } = action.payload;
			document.cookie = `Bearer=${token};`;
			return {
				...state,
				user: {
					...user,
				},
				isLoggedIn: true,
			};
		case DispatchTypes.LOGOUT:
			document.cookie = "Bearer= ;";
			return {
				...state,
				user: {
					userId: "",
					username: "",
				},
				isLoggedIn: false,
			};
		default:
			return state;
	}
};
