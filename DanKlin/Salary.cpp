#include <iostream>
#include <fstream>
#include <map>
#include <sstream>
#include <string>

struct WorkGroup {
    int salarySum,peopleCount;
};

 typedef std::map<std::string, WorkGroup> Groups;

int main(int argc, char* argv[])
{
    if (argc < 2) {
        std::cout << "You didn't write input file name.";
        return 1;
    }

    std::string filename = (std::string)argv[1];
    std::ifstream input(filename.c_str());

    if (!input.good()) {
        std::cout << "File " << filename << " doesn't exist.";
        return 1;
    } else {
        Groups groups;
        std::string groupName;
        int salaryNow;
        std::string lineStr;

        while (std::getline(input,lineStr)) {

            if (lineStr.length() == 0){
                continue;
            }

            std::stringstream line(lineStr);
            line >> groupName >> groupName >> salaryNow;

            auto it = groups.find(groupName);
            if (it == groups.end()){
                WorkGroup a;
                a.salarySum = salaryNow;
                a.peopleCount = 1;
                groups[groupName] = a;
            } else {
                groups[groupName].salarySum += salaryNow;
                groups[groupName].peopleCount++;
            }
        }
        input.close();

        std::ofstream output(filename.c_str());
        for (auto x:groups){
            output << x.first << '\t'
                << x.second.salarySum/x.second.peopleCount << ' '
                << x.second.salarySum << std::endl;
        }
        output.close();
    }

    return 0;
}
