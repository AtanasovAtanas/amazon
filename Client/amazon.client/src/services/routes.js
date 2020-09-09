const BASE_URL = "https://localhost:5001/";
const IDENTITY_BASE_URL = BASE_URL + "Identity/";
const CATEGORIES_BASE_URL = BASE_URL + "Categories/";

export const IdentityRoutes = {
	LOGIN: `${IDENTITY_BASE_URL}Login`,
	REGISTER: `${IDENTITY_BASE_URL}Register`,
	GET_IDENTITY_DETAILS: IDENTITY_BASE_URL,
};

export const CategoryRoutes = {
	GET_ALL: `${CATEGORIES_BASE_URL}All`,
};
