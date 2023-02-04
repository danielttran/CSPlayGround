#include <Windows.h>
#include <iostream>
#include <fstream>
#include <set>
#include <string>
#include <thread>

std::set<std::string> clipboard_contents;

void SaveToFile()
{
	std::ofstream output_file("C:\\Users\\Daniel\\Desktop\\aa.md");
	for (const auto& content : clipboard_contents)
	{
		output_file << content << std::endl;
	}
}

void MonitorClipboard()
{
	while (true)
	{
		if (OpenClipboard(nullptr))
		{
			HANDLE handle = GetClipboardData(CF_TEXT);
			if (handle)
			{
				char* buffer = (char*)GlobalLock(handle);
				std::string clipboard_text(buffer);
				GlobalUnlock(handle);
				if (clipboard_text.find("leetcode.com") != std::string::npos)
				{
					clipboard_contents.insert(clipboard_text);
				}
			}
			EmptyClipboard();
			CloseClipboard();
		}
		Sleep(500);
	}
}

int main()
{
	std::thread monitor_thread(MonitorClipboard);

	std::cout << "Press enter to stop the program." << std::endl;
	std::cin.get();

	monitor_thread.detach();

	SaveToFile();

	return 0;
}
