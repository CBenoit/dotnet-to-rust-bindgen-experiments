#include <iostream>
#include <string_view>

#include "PickyPem.hpp"

int main() {
  PickyPem pem = PickyPem::load_from_file({"/home/auroden/git/picky-rs/test_assets/intermediate_ca.crt"}).ok().value();
  std::cout << "label: " << pem.label().ok().value() << "\n";
  PickyError e = PickyPem::load_from_file({"/home/auroden/giticky-rs/test_assets/intermediate_ca.crt"}).err().value();
  std::cout << "error: " << e.display() << "\n";
  return 0;
}
