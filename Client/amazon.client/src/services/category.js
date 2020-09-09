import crud from "./crud";
import { CategoryRoutes } from "./routes";

const defaultHeader = {
	"Content-Type": "application/json",
};

const getAll = async (onSuccess, onFailure) => {
	await crud.get(CategoryRoutes.GET_ALL, defaultHeader, onSuccess, onFailure);
};

const categoriesService = {
	getAll,
};

export default categoriesService;
