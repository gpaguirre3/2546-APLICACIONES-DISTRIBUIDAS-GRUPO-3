"use client";

import React from 'react';

const Button = ({ children, onClick, className = '', ...props }) => {
  return (
    <button
      onClick={onClick}
      className={`px-4 py-2 sm:px-6 sm:py-3 bg-blue-500 text-white font-bold rounded transition-transform transform hover:scale-105 focus:outline-none focus:ring-2 focus:ring-blue-300 ${className}`}
      {...props}
    >
      {children}
    </button>
  );
};

export default Button;