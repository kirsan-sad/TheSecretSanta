import React, { useEffect, useState } from 'react';
import WishItem from "./WishItem";
import AddWish from './AddWish';

const WishList = ({wishes, isLoading}) => {
    console.log("render WishList");
    const [wish, setWish] = useState([]);
    const [showForm, setShowForm] = useState(false);
    
    useEffect(() =>{
      if(wishes)
        setWish(sortByIsCompleted(Object.values(wishes)));
    }, [wishes])

    const addNewHandle = () => {
      setShowForm(!showForm);
    };

    const sortByIsCompleted = (arr) => {
      return arr.sort((a, b) => {
        if (a.fields.isCompleted && !b.fields.isCompleted) {
          return 1;
        }
        if (!a.fields.isCompleted && b.fields.isCompleted) {
          return -1;
        }
        return 0;
      });
    };

    if (isLoading) return <div>Loading...</div>;

  return (
    <div className="flex justify-center">
      <div className="max-w-xl w-full mx-auto">
        <div className="mt-10">
          <button 
            className="max-w-xl w-full mx-auto bg-emerald-500 hover:bg-emerald-700 text-white font-bold py-2 px-4 rounded" 
            onClick={addNewHandle}>
            Add your wish
          </button>
          {showForm && <AddWish setShowForm={setShowForm}/>}
        </div>
        
        {wish && wish.map(wish => {
          return <WishItem key = {wish.id} wish={wish}/>
        })}
      </div>
    </div>
  )
}

export default WishList