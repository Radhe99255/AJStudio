$(document).ready(function () {


    const stateData = {
        'Andhra Pradesh': [
            'Adoni', 'Amaravati', 'Anantapur', 'Chandragiri', 'Chittoor', 'Dowlaiswaram', 'Eluru',
            'Guntur', 'Kadapa', 'Kakinada', 'Kurnool', 'Machilipatnam', 'Nagarjunakonda', 'Nandyal',
            'Nellore', 'Ongole', 'Proddatur', 'Puttaparthi', 'Rajahmundry', 'Srikakulam',
            'Tadepalligudem', 'Tirupati', 'Vijayawada', 'Visakhapatnam', 'Vizianagaram',
            'Yemmiganur', 'Bhimavaram', 'Tuni', 'Tenali', 'Srikalahasti', 'Palasa Kasibugga',
            'Madanapalle', 'Guntakal', 'Dharmavaram', 'Gudivada', 'Narasaraopet', 'Rajampet',
            'Sattenapalle'
        ],
        'Arunachal Pradesh': [
            'Itanagar', 'Naharlagun', 'Pasighat', 'Tawang', 'Ziro', 'Tezu', 'Bomdila'
        ],
        'Assam': [
            'Guwahati', 'Silchar', 'Dibrugarh', 'Jorhat', 'Nagaon', 'Tinsukia', 'Tezpur', 'Bongaigaon',
            'Karimganj', 'Sivasagar', 'Dhubri'
        ],
        'Bihar': [
            'Patna', 'Gaya', 'Bhagalpur', 'Muzaffarpur', 'Purnia', 'Darbhanga', 'Bihar Sharif',
            'Ara', 'Begusarai', 'Katihar', 'Munger', 'Chhapra', 'Danapur'
        ],
        'Chhattisgarh': [
            'Raipur', 'Bhilai', 'Bilaspur', 'Korba', 'Durg', 'Rajnandgaon', 'Jagdalpur', 'Raigarh',
            'Ambikapur', 'Dhamtari', 'Mahasamund'
        ],
        'Goa': [
            'Panaji', 'Margao', 'Vasco da Gama', 'Mapusa', 'Ponda'
        ],
        'Gujarat': [
            'Ahmedabad', 'Surat', 'Vadodara', 'Rajkot', 'Bhavnagar', 'Jamnagar', 'Junagadh',
            'Gandhinagar', 'Gandhidham', 'Anand', 'Navsari', 'Bharuch', 'Mehsana', 'Bhuj'
        ],
        'Haryana': [
            'Faridabad', 'Gurugram', 'Panipat', 'Ambala', 'Yamunanagar', 'Rohtak', 'Hisar',
            'Karnal', 'Sonipat', 'Panchkula', 'Bhiwani'
        ],
        'Himachal Pradesh': [
            'Shimla', 'Dharamshala', 'Solan', 'Mandi', 'Palampur', 'Baddi', 'Nahan', 'Una',
            'Hamirpur', 'Kullu'
        ],
        'Jharkhand': [
            'Ranchi', 'Dhanbad', 'Jamshedpur', 'Bokaro Steel City', 'Deoghar', 'Phusro', 'Hazaribagh',
            'Giridih', 'Ramgarh', 'Medininagar (Daltonganj)', 'Chirkunda'
        ],
        'Karnataka': [
            'Bengaluru', 'Mysore', 'Hubli-Dharwad', 'Mangalore', 'Belgaum', 'Gulbarga', 'Davangere',
            'Bellary', 'Bijapur', 'Shimoga', 'Tumkur', 'Raichur'
        ],
        'Kerala': [
            'Thiruvananthapuram', 'Kochi', 'Kozhikode', 'Kollam', 'Thrissur', 'Alappuzha', 'Palakkad',
            'Malappuram', 'Ponnani', 'Kasaragod', 'Kanhangad'
        ],
        'Madhya Pradesh': [
            'Bhopal', 'Indore', 'Gwalior', 'Jabalpur', 'Ujjain', 'Sagar', 'Ratlam', 'Satna', 'Dewas',
            'Murwara', 'Singrauli', 'Burhanpur'
        ],
        'Maharashtra': [
            'Mumbai', 'Pune', 'Nagpur', 'Nashik', 'Thane', 'Aurangabad', 'Solapur', 'Amravati',
            'Kolhapur', 'Akola', 'Jalgaon', 'Latur', 'Dhule'
        ],
        'Manipur': [
            'Imphal', 'Churachandpur', 'Thoubal', 'Bishnupur', 'Senapati', 'Ukhrul', 'Kakching'
        ],
        'Meghalaya': [
            'Shillong', 'Tura', 'Nongstoin', 'Jowai', 'Baghmara', 'Williamnagar', 'Nongpoh'
        ],
        'Mizoram': [
            'Aizawl', 'Lunglei', 'Saiha', 'Champhai', 'Kolasib', 'Serchhip', 'Lawngtlai'
        ],
        'Nagaland': [
            'Kohima', 'Dimapur', 'Mokokchung', 'Tuensang', 'Wokha', 'Zunheboto', 'Kiphire'
        ],
        'Odisha': [
            'Bhubaneswar', 'Cuttack', 'Rourkela', 'Berhampur', 'Sambalpur', 'Puri', 'Balasore',
            'Bhadrak', 'Baripada', 'Jharsuguda', 'Angul'
        ],
        'Punjab': [
            'Ludhiana', 'Amritsar', 'Jalandhar', 'Patiala', 'Bathinda', 'Hoshiarpur', 'Mohali',
            'Batala', 'Pathankot', 'Moga'
        ],
        'Rajasthan': [
            'Jaipur', 'Jodhpur', 'Kota', 'Bikaner', 'Ajmer', 'Udaipur', 'Bhilwara', 'Alwar',
            'Bharatpur', 'Sri Ganganagar', 'Sikar', 'Pali'
        ],
        'Sikkim': [
            'Gangtok', 'Namchi', 'Geyzing', 'Mangan', 'Singtam', 'Rangpo', 'Jorethang'
        ],
        'Tamil Nadu': [
            'Chennai', 'Coimbatore', 'Madurai', 'Tiruchirappalli', 'Salem', 'Tirunelveli',
            'Vellore', 'Erode', 'Tiruppur', 'Thoothukudi', 'Nagercoil', 'Thanjavur'
        ],
        'Telangana': [
            'Hyderabad', 'Warangal', 'Nizamabad', 'Khammam', 'Karimnagar', 'Ramagundam',
            'Mahbubnagar', 'Nalgonda', 'Adilabad', 'Suryapet'
        ],
        'Tripura': [
            'Agartala', 'Udaipur', 'Dharmanagar', 'Kailasahar', 'Belonia', 'Khowai'
        ],
        'Uttar Pradesh': [
            'Lucknow', 'Kanpur', 'Ghaziabad', 'Agra', 'Meerut', 'Varanasi', 'Allahabad',
            'Bareilly', 'Aligarh', 'Moradabad', 'Saharanpur', 'Gorakhpur'
        ],
        'Uttarakhand': [
            'Dehradun', 'Haridwar', 'Roorkee', 'Haldwani', 'Rudrapur', 'Kashipur', 'Rishikesh'
        ],
        'West Bengal': [
            'Kolkata', 'Asansol', 'Siliguri', 'Durgapur', 'Bardhaman', 'Malda', 'Baharampur',
            'Habra', 'Kharagpur', 'Shantipur'
        ]
    };

    $('#state').on('change', function () {

        //Get selected state data
        const selectedState = $(this).val();

        //Get City DropDown
        const cityDropDown = $('#city');

        //Clear existing options
        cityDropDown.html("");

        //Update City Dropdown based on state selected
        if (selectedState && stateData[selectedState]) {
            $.each(stateData[selectedState], function (index, city) {
                cityDropDown.append($('<option>', {
                    value: city,
                    text: city
                }));
            });
        }
        else {
            cityDropDown.html('<option value="">Select City</option>');
        }
    });
});
