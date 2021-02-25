public class Solution {
    public int RomanToInt(string s) {
        // Create key/value pairs for each Roman numeral
        var romanNumeralsDict = new Dictionary<char, int>() {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        char tempChar;
        char peekNext;
        int total = 0;
        int charsToRemove = 1;

        if(s.Length >= 1 && s.Length <= 15) {
            while(s.Length > 0) {
                tempChar = s[0];
                charsToRemove = 1;

                if(romanNumeralsDict.ContainsKey(tempChar)) {
                    if(s.Length > 1) {
                        if(tempChar == 'I') {
                            peekNext = s[1];
                            if(peekNext == 'V' || peekNext == 'X') {
                                total += romanNumeralsDict[peekNext] - romanNumeralsDict[tempChar];
                                charsToRemove = 2;
                            }
                            else {
                                total += romanNumeralsDict[tempChar];
                            }
                        }
                        else if(tempChar == 'X') {
                            peekNext = s[1];
                            if(peekNext == 'L' || peekNext == 'C') {
                                total += romanNumeralsDict[peekNext] - romanNumeralsDict[tempChar];
                                charsToRemove = 2;
                            }
                            else {
                                total += romanNumeralsDict[tempChar];
                            }
                        }
                        else if(tempChar == 'C') {
                            peekNext = s[1];
                            if(peekNext == 'D' || peekNext == 'M') {
                                total += romanNumeralsDict[peekNext] - romanNumeralsDict[tempChar];
                                charsToRemove = 2;
                            }
                            else {
                                total += romanNumeralsDict[tempChar];
                            }
                        }
                        else {
                            total += romanNumeralsDict[tempChar];
                        }
                    }
                    else {
                        total += romanNumeralsDict[tempChar];
                    }
                }

                s = s.Remove(0, charsToRemove);
            }
        }

        return total;
    }
}
