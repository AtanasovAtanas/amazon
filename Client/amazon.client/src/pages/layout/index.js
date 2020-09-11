import React from "react";
import Navbar from "../../components/navbar/Navbar";

const PageLayout = ({ children }) => {
	return (
		<div>
			<Navbar />
			{children}
		</div>
	);
};

export default PageLayout;
