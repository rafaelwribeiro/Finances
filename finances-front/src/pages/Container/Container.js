import styles from "./Container.module.css";

const Container = ({Item}) =>{
    return (
        <div className={styles.containerBody}>
            <div className={styles.containerSideBar}>
                <ul>
                    <li>
                        <a href="#">HOME</a>
                    </li>
                    <li>
                        <a href="#">MOVEMENTS</a>
                    </li>
                    <li>
                        <a href="#">CATEGORIES</a>
                    </li>
                </ul>
            </div>
            <div className={styles.containerContent}>
            <Item />
            </div>
            <footer></footer>
        </div>
    );
};

export default Container;