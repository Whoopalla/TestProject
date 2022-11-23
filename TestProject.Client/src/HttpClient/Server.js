import axios from 'axios'


const endpoint = process.env.REACT_APP_SERVICE_URI? process.env.REACT_APP_SERVICE_URI : 'http://localhost:57678/'

async function GetArraySum(numbers) {
    
    const response = axios.post(endpoint + 'FirstTask', { numbers }, { mode: 'cors' })
    .catch(function (error) {
        console.log(error);
    });
    return response;
} 

async function GetTwoLinkedListsSum(firstNumberNode, secondNumberNode) {
    
    const response = axios.post(endpoint + 'SecondTask', { firstNumberNode, secondNumberNode }, { mode: 'cors' })
    .catch(function (error) {
        console.log(error);
    });
    return response;
} 

async function isStringPalindrome(input) {
    
    const response = axios.post(endpoint + 'ThirdTask', { input }, { mode: 'cors' })
    .catch(function (error) {
        console.log(error);
    });
    return response;
} 

export {GetArraySum as default, GetTwoLinkedListsSum, isStringPalindrome};