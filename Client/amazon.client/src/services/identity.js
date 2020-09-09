import crud from "./crud";
import { IdentityRoutes } from "./routes";
import getCurrentBearerToken from "./cookie-helper";

const authenticate = async (type, body, onSuccess, onFailure) => {
	if (type === "LOGIN") {
		await login(body, onSuccess, onFailure);
	} else if (type === "REGISTER") {
		await register(body, onSuccess, onFailure);
	}
};

const login = async (body, onSuccess, onFailure) => {
	await crud.input(
		IdentityRoutes.LOGIN,
		"POST",
		{
			"Content-Type": "application/json",
		},
		body,
		onSuccess,
		onFailure
	);
};

const register = async (body, onSuccess, onFailure) => {
	if (body.password !== body.repeatpassword) {
		onFailure("Password and repeat password don't match");
		return;
	}

	await crud.input(
		IdentityRoutes.REGISTER,
		"POST",
		{
			"Content-Type": "application/json",
		},
		body,
		onSuccess,
		onFailure
	);
};

const getIdentityDetails = async (onSuccess, onFailure) => {
	const token = getCurrentBearerToken();
	if (!token) {
		return;
	}

	await crud.get(
		IdentityRoutes.GET_IDENTITY_DETAILS,
		{
			"Content-Type": "application/json",
			Authorization: token,
		},
		onSuccess,
		onFailure
	);
};

const identityService = {
	authenticate,
	getIdentityDetails,
};

export default identityService;
