import React from "react";
import styles from "./Navbar.module.css";
import { Link } from "react-router-dom";
import { useGlobalContext } from "../../context/context";
import SearchIcon from "@material-ui/icons/Search";
import ShoppingCartIcon from "@material-ui/icons/ShoppingCart";
import AccountBoxIcon from "@material-ui/icons/AccountBox";
import ExitToAppIcon from "@material-ui/icons/ExitToApp";
import HistoryIcon from "@material-ui/icons/History";

const Navbar = () => {
	const { isLoggedIn, logout } = useGlobalContext();

	return (
		<nav className={styles.header}>
			<Link to="/">
				<img src="logo.png" className={styles.logo} alt="logo" />
			</Link>

			<div className={styles.search}>
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
						<Link to="/purchases">
							<div className={styles.links}>
								<HistoryIcon />
								<span>Purchases</span>
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
