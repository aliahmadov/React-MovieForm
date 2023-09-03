import React, { Component, useContext } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import './custom.css';
import MovieList from './components/MovieList/MovieList';



export default class App extends Component {
    static displayName = App.name;

    render() {
        return (

            <div >
                <MovieList></MovieList>

            </div>

        );
    }
}
