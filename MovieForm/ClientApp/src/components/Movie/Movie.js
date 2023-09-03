import { React, Component } from 'react';
import './movie.css'


export default function Movie({ movie, handleDeleteMovie }) {



    return (
        <div className="movie-box">
            {
                <div>
                    <h3>{movie.movieName}</h3>
                    <div>
                        <img className="poster-img" src={movie.posterUrl} />
                    </div>
                </div>
            }
            <h5 onClick={() => handleDeleteMovie(movie.id)} style={{ color: "red", border: "1px solid red", padding: "10px 30px",marginTop:"10px",width:"50%",textAlign:'center' }}>Delete</h5>
        </div>
    )
}