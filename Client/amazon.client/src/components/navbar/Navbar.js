import React, { useState } from "react";
import styles from "./Navbar.module.css";
import { Link } from "react-router-dom";
import SearchIcon from "@material-ui/icons/Search";
import ShoppingCartIcon from "@material-ui/icons/ShoppingCart";

const Navbar = () => {
	const [searchStyles, setSearchStyles] = useState(styles.search);

	return (
		<nav className={styles.header}>
			<Link to="/">
				<img src="logo.png" className={styles.logo} />
			</Link>

			<div className={searchStyles}>
				<input
					type="text"
					className={styles["search-input"]}
					onFocus={() => setSearchStyles(styles["search-active"])}
					onBlur={() => setSearchStyles(styles.search)}
				/>
				<SearchIcon className={styles["search-icon"]} />
			</div>

			<div className={styles.links}>
				<Link to="/login">Login</Link>
				<Link to="/register">Register</Link>
				<Link to="/checkout">
					<ShoppingCartIcon />
				</Link>
			</div>
		</nav>
	);
};

export default Navbar;
