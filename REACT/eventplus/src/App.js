import Rotas from './routes/routes';
import { UserContext } from './context/AuthContext';
import './App.css';
import { useEffect, useState } from 'react';

const App = () => {
    const [userData, setUserData] = useState({})
    useEffect(() => {
        const token = localStorage.getItem("token");
        setUserData( token === null ? {} : JSON.parse(token) )
    }, [])
    return(

    <UserContext.Provider value={ {userData, setUserData} }>
        <Rotas/>
    </UserContext.Provider>
    );
 };
export default App;
