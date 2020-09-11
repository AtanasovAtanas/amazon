import React from "react";
import styles from "./Navbar.module.css";
import Select from "../select/Select";
import { Link } from "react-router-dom";
import { useGlobalContext } from "../../context/context";
import SearchIcon from "@material-ui/icons/Search";
import ShoppingCartIcon from "@material-ui/icons/ShoppingCart";
import AccountBoxIcon from "@material-ui/icons/AccountBox";
import ExitToAppIcon from "@material-ui/icons/ExitToApp";
import FavoriteIcon from "@material-ui/icons/Favorite";

const Navbar = () => {
	const { isLoggedIn, logout } = useGlobalContext();
	const { categories } = useGlobalContext();

	return (
		<nav className={styles.header}>
			<Link to="/">
				<img src="logo.png" className={styles.logo} alt="logo" />
			</Link>

			<div className={styles.search}>
				<Select options={categories.map((category) => category.name)} />
				<input type="text" className={styles["search-input"]} />
				<SearchIcon className={styles["search-icon"]} />
			</div>

			<div className={styles.links}>
				{isLoggedIn ? (
					<>
						<Link to="/profile">
							<div className={styles.links}>
								<AccountBoxIcon />
								<span>Profile</span>
							</div>
						</Link>
						<Link to="/favorites">
							<div className={styles.links}>
								<FavoriteIcon />
								<span>Favorites</span>
							</div>
						</Link>
						<Link to="/checkout">
							<div className={styles.links}>
								<ShoppingCartIcon />
								Cart
							</div>
						</Link>
						<Link to="/" onClick={logout}>
							<div className={styles.links}>
								<ExitToAppIcon />
								<span>Logout</span>
							</div>
						</Link>
					</>
				) : (
					<>
						<Link to="/login">Login</Link>
						<Link to="/register">Register</Link>
						<Link to="/checkout">
							<div className={styles.links}>
								<ShoppingCartIcon />
								Cart
							</div>
						</Link>
					</>
				)}
			</div>
		</nav>
	);
};

export default Navbar;
