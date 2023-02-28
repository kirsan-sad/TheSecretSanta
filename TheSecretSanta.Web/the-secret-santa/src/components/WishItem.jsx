import React, { useState } from 'react'
import { useUpdateWishMutation } from '../services/wishApi';
import categories from '../utils/categories';

const WishItem = ({wish}) => {
  const {id, fields} = wish;
  const [showForm, setShowForm] = useState(fields.isCompleted);
  console.log("render WishItem");
  const [updateWish] = useUpdateWishMutation();

  const toggleForm = () => {
    setShowForm(!showForm);
  };

  const completeHandle = async () =>{
    if(!fields.isCompleted){
      const updatedFields = {
        ...fields,
        isCompleted: true
      };
      const body = JSON.stringify(updatedFields);
      await updateWish({body:body, id:id});
      setShowForm(!showForm);
    } 
  };
  
  return (
    <div className="mx-auto my-4">
      <div className="rounded overflow-hidden shadow-lg mx-auto my-4 bg-white">
      <div className={`flex items-center justify-between ${fields.isCompleted ? "bg-gray-200" : "bg-white" }  px-6 py-4 cursor-pointer`} onClick={toggleForm}>
      <span className="font-bold">{fields.isCompleted ? `Wish №${fields.wishNumber} Booked` : `Wish №${fields.wishNumber} Available`}</span>
        <svg className="w-6 h-6 text-gray-600" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
          {!showForm ? (
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M20 12H4" />
          ) : (
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 6v12M6 12h12" />
          )}
        </svg>
      </div>
        <div className={`px-6 py-4 ${!showForm ? "block" : "hidden"} transition-all ease-in-out duration-500`}>
          <div className="mb-4">
            <label htmlFor="category" className="block text-neutral-700 font-bold mb-2">
              Category
            </label>
            <select
              readOnly
              value={fields.category}
              id="category"
              name="category"
              className="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline"
            >
              {categories.map((category) => (
              <option
                key={category.id}
                value={category.label}
                defaultValue={category.label === fields.category}>
                  {category.label}
              </option>
            ))}
            </select>
          </div>
  
          <div className="mb-4">
            <label htmlFor="adult" className="block text-neutral-700 font-bold mb-2">
              Adult 18+
            </label>
            <input
              type="checkbox"
              name="adult"
              id="adult"
              className="mr-2 leading-tight"
              disabled 
              defaultChecked={fields.isAdult}
            />
            <label htmlFor="adult" className="text-sm">
              Check this box if this wish is for adults only
            </label>
          </div>
  
          <div className="mb-4">
            <label htmlFor="date" className="block text-neutral-700 font-bold mb-2">
              Date
            </label>
            <input
              readOnly
              type="date"
              name="date"
              id="date"
              className="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline"
              value={fields.date}
            />
          </div>
  
          <div className="mb-4">
            <label htmlFor="wish" className="block text-neutral-700 font-bold mb-2">
              Wish
            </label>
            <textarea
              name="wish"
              id="wish"
              rows="3"
              className="block appearance-none w-full bg-white border border-gray-400 hover:border-gray-500 px-4 py-2 pr-8 rounded shadow leading-tight focus:outline-none focus:shadow-outline"
              disabled 
              defaultValue={fields.wish}>
              </textarea>
          </div>
  
          <div className="mb-4">
            <label htmlFor="completed" className="block text-neutral-700 font-bold mb-2">
              Completed
            </label>
            <input
              type="checkbox"
              name="completed"
              id="completed"
              className="mr-2 leading-tight"
              onChange={completeHandle} 
              disabled={fields.isCompleted} 
              defaultChecked={fields.isCompleted}
            />
            <label htmlFor="completed" className="text-sm">
              Check this box if this wish has been completed
            </label>
          </div>
        </div>
      </div>
    </div>
  );
}

export default WishItem