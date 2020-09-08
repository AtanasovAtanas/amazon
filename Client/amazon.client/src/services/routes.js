const BASE_URL = "https://localhost:5001/";
const IDENTITY_BASE_URL = BASE_URL + "Identity/";

export const IdentityRoutes = {
	LOGIN: `${IDENTITY_BASE_URL}Login`,
	REGISTER: `${IDENTITY_BASE_URL}Register`,
	GET_IDENTITY_DETAILS: IDENTITY_BASE_URL,
};
