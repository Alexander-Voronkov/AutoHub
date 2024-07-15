import React from 'react';
import '../css/AdditionalOptions.css';

const AdditionalOptions = ({ title, options, columns }) => {
  const columnWrapper = {};
  const result = [];
  for (let i = 0; i < columns; i++) {
    columnWrapper[`col${i}`] = [];
  }
  for (let i = 0; i < options.length; i++) {
    columnWrapper[`col${i % columns}`].push(options[i]);
  }
  for (let i = 0; i < columns; i++) {
    result.push(columnWrapper[`col${i}`]);
  }
  return (
    <div className="additional-options">
      <h2>{title}</h2>
      <div className="options-columns">
        {result.map((column, index) => (
          <ul key={index}>
            {column.map((option, idx) => (
              <li key={idx}>{option}</li>
            ))}
          </ul>
        ))}
      </div>
    </div>
  );
};

export default AdditionalOptions;
