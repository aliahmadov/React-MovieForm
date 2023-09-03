import React, { Component, useEffect, useState } from 'react';
import './movieList.css';
import Movie from '../Movie/Movie';

export default function MovieList() {
    const [movies, setMovies] = useState([]);
    const [movieName, setMovieName] = useState("");
    const [posterUrl, setPosterUrl] = useState("");

    useEffect(() => {
        fetchMovies();
    }, []);

    const fetchMovies = async () => {
        try {
            const response = await fetch('https://localhost:7179/api/Movie', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (response.ok) {
                const data = await response.json();
                setMovies(data);
            } else {
                console.error('Failed to fetch movies:', response.status);
            }
        } catch (error) {
            console.error('Error fetching movies:', error);
        }

    };
    useEffect(() => {
        console.log(movies);
    }, [movies]);

    function handleMovieName(event) {
        setMovieName(event.target.value);
    }

    function handleMoviePoster(event) {
        setPosterUrl(event.target.value);

    }

    async function handleAddMovie(event) {
        let url = 'https://localhost:7179/api/Movie';
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                movieName: movieName,
                posterUrl: posterUrl,
                productionYear: "",
                trailerUrl: ""
            })
        }

        try {
            const response = await fetch(url, requestOptions);
            if (response.ok) {
                // Movie added successfully, so fetch the updated movie list
                await fetchMovies();
                // Clear input fields
               
            } else {
                console.error('Failed to add movie:', response.status);
            }
        } catch (error) {
            console.error('Error adding movie:', error);
        }


      

    }

    async function handleDeleteMovie(id) {
        console.log(id);
        try {
            await fetch(`https://localhost:7179/api/Movie/${id}`, { method: 'DELETE' });
            // Movie deleted successfully, so fetch the updated movie list
            await fetchMovies();
            alert('Deleted Successfully');
        } catch (error) {
            console.error('Error deleting movie:', error);
        }
    }

    return (

        <div >
            <div className="movie-container">
                {
                    movies.map((m) => (
                        <Movie handleDeleteMovie={()=>handleDeleteMovie(m.id)} key={m.id} movie={m}></Movie>
                    ))
                }

            </div>

            <div className="form-cont">
                <h2>Movie Form</h2>
                <div>
                    <p>Movie Name</p>
                    <input onChange={(e) => handleMovieName(e)} type="text"></input>
                </div>
                <div>
                    <p>Movie Poster Url</p>
                    <input onChange={(e) => handleMoviePoster(e)} type="text"></input>
                </div>

                <div>
                    <button onClick={((e) => handleAddMovie(e))}>
                        Add Movie
                    </button>
                </div>
            </div>
        </div>


    )
}