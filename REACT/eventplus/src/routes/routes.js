import React from 'react';

import { BrowserRouter, Routes, Route } from 'react-router-dom';

import EventosPage from '../pages/EventosPage/EventosPage';
import LoginPage from "../pages/LoginPage/LoginPage"
import HomePage from '../pages/HomePage/HomePage';
import TipoEventos from '../pages/TipoEventos/TipoEventos'
import TestePage from '../pages/Teste/TestePage';
import Header from '../components/Header/Header';
import Footer from '../components/Footer/Footer';
import { PrivateRoute } from "./PrivateRoute"
import EventosAlunoPage from '../pages/EventosAlunoPage/EventosAlunoPage';


const Rotas = () => {
    return (
            <BrowserRouter>
               <Header/>
                <Routes>
                    <Route element={<HomePage/>} path="/" />
                    
                    <Route element={
                    <PrivateRoute>
                        <TipoEventos/>
                    </PrivateRoute> }
                     path={"/tipo-evento"} />

                    <Route element={
                    <PrivateRoute>
                        <EventosPage/>
                    </PrivateRoute>
                    
                    } path={"/evento"} />

                    <Route element={
                    <PrivateRoute redirectTo='/'>
                        <EventosAlunoPage/>
                    </PrivateRoute>
                    
                    } path={"/eventos-aluno"} />
                    <Route element={<LoginPage/>} path={"/login"} />
                    <Route element={<TestePage/>} path={"/teste"} />
                </Routes>
                <Footer />
            </BrowserRouter>

    );
};

export default Rotas;